using System;
using System.Collections.Generic;
using System.Linq;

namespace TTT
{
    class Pos
    {
        public int x { get; set; }
        public int y { get; set; }


        public Pos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class BoardState
    {
        public char[,] board { get; set; }
        public int turn { get; set; }
        public int depth { get; set; }
        public int alpha { get; set; }
        public int beta { get; set; }
        public int winner { get; set; }
        public BoardState nextMove { get; set; }


        public BoardState(char[,] board, int turn, int depth, int alpha, int beta)
        {
            this.board = board;
            this.turn = turn;  //0-max-computer  1-min-player
            this.depth = depth;   // 0-root
            this.alpha = alpha;
            this.beta = beta;
        }

        public BoardState() : this(new char[3, 3] { { '_', '_', '_' }, { '_', '_', '_' }, { '_', '_', '_' } }, 0, 0, int.MinValue, int.MaxValue)
        {

        }

        //public BoardState() : this(new char[3, 3] { { 'x', 'o', '_' }, { 'x', 'o', '_' }, { '_', '_', '_' } }, 0, 0, int.MinValue, int.MaxValue)
        //{

        //}

        public Pos getInputPos()
        {
            string s = Console.ReadLine();
            string[] result = s.Split(' ');
            
            return new Pos(Convert.ToInt32(result[0]), Convert.ToInt32(result[1]));
        }

        public void drawBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public void updateBoard(Pos p, char c)
        {
            if (board[p.x, p.y] != '_')
            {
                Console.WriteLine("Invalid move. Please enter again.");
                
                updateBoard(getInputPos(), 'o');
            }
            else
            {
                board[p.x, p.y] = c;
            }
        }

        public int getScore()
        {
            if (checkFinish(out char w))
            {
                if (w == 'o')
                {
                    //Console.WriteLine("you win.");
                    return depth-1000;
                }
                if (w == 'x')
                {
                    //Console.WriteLine("you lose.");
                    return 1000-depth;
                }
                if (w == 't')
                {
                    //Console.WriteLine("Tie");
                    return 0;
                }
            }

            List<Pos> availableMoves = getAvailableMoves();

            // Max,  computer's turn
            if(turn == 0)
            {
                int maxInChild = int.MinValue;
                foreach(var move in availableMoves)
                {
                    BoardState childState = new BoardState(newBoard(move, 'x'), changeTurn(turn), depth + 1, alpha, beta);
                    int childScore = childState.getScore();

                    if(childScore > maxInChild)
                    {
                        maxInChild = childScore;
                        alpha = maxInChild;
                        nextMove = childState;
                    }

                    if (alpha >= beta)
                        break;
                }
                return maxInChild;
            }


            //Min, player's turn
            else if(turn == 1)
            {
                int minInChild = int.MaxValue;
                foreach(var move in availableMoves)
                {
                    BoardState childState = new BoardState(newBoard(move, 'o'), changeTurn(turn), depth + 1, alpha, beta);
                    int childScore = childState.getScore();

                    if(childScore < minInChild)
                    {
                        minInChild = childScore;
                        beta = minInChild;
                        nextMove = childState;
                    }

                    if (alpha >= beta)
                        break;
                }

                return minInChild;
            }


            return 0;
        }

        private int changeTurn(int turn)
        {
            return turn == 1 ? 0 : 1;
        }

        public char[,] newBoard(Pos p, char c)
        {
            //char[,] newboard = new char[3,3];
            //for (int i = 0; i < 3; i++)
            //    for (int j = 0; j < 3; j++)
            //        newboard[i, j] = board[i, j];

            char[,] newboard = (char[,])board.Clone();
            newboard[p.x, p.y] = c;
            return newboard;
        }

        public List<Pos> getAvailableMoves()
        {
            List<Pos> result = new List<Pos>();
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '_')
                        result.Add(new Pos(i, j));
                }
            }

            return result;
        }

        public bool checkFinish(out char winner)
        {
            //check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != '_')
                {
                    winner = board[i, 0];
                    return true;
                }
                    
            }

            //check cols
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == board[1, i] && board[2, i] == board[1, i] && board[0, i] != '_')
                {
                    winner = board[0, i];
                    return true;
                }
                    
            }

            //check diagonal
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0,0] != '_')
            {
                winner = board[0, 0];
                return true;
            }
            if (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2] && board[2, 0] != '_')
            {
                winner = board[2, 0];
                return true;
            }


            // no available move, there is a tie
            if (!getAvailableMoves().Any())
            {
                winner = 't';
                return true;
            }

            // not finished, set winner to '_'
            winner = '_';
            return false;
        }
        

        public void move()
        {
            board = nextMove.board;
            drawBoard();
        }

    }
}
