using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakuGoCmd
{

    class Program
    {
        static void Main(string[] args)
        {
            BoardState bs = new BoardState();
            char[,] testBoard = new char[15, 15] {
                { '_', '_', '_', '_', '_', 'o', 'o', 'o', '_', '_', 'o', 'o', 'o', 'o', '_', },// 1
                { 'x', '_', '_', '_', '_', '_', '_', '_', 'o', '_', '_', '_', '_', '_', '_', },// 2
                { 'x', 'x', '_', '_', '_', '_', '_', 'o', '_', '_', '_', '_', '_', '_', '_', },// 3
                { 'x', '_', 'x', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 4
                { 'o', '_', '_', 'x', '_', 'o', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 5
                { 'x', '_', '_', '_', 'o', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 6
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 7
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 8
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 9
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 10
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 11
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 12
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 13
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 14
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 15
            };

            List<Pos> winningPath = new List<Pos>();
            winningPath = bs.checkFinished(testBoard);

            bs.board = testBoard;
            if(bs.hasNeighbor(1, 3, 1))
            {
                Console.WriteLine("has neighbor.");
            }
            bs.drawBoard();
        }
    }


    public class Pos
    {
        public int x { get; set; }
        public int y { get; set; }


        public Pos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class BoardState
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

        // 初始化数组为 '_'
        public static char[,] initBoard()
        {
            char[,] Board = new char[15, 15];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Board[i, j] = '_';
                }
            }
            return Board;
        }

        public BoardState() : this(initBoard(), 0, 0, int.MinValue, int.MaxValue)
        {

        }

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

        public int minimax()
        {
            List<Pos> result = checkFinished(board);
            if(result.Count == 5)
            {
                if(board[result[0].x, result[0].y] == 'x')
                {
                    Console.WriteLine("winner is x.");
                    return 100000;
                }

                if (board[result[0].x, result[0].y] == 'o')
                {
                    Console.WriteLine("winner is o.");
                    return -100000;
                }
            }

            if(result.Count == 1)
            {
                Console.WriteLine("Tie.");
                return 0;
            }

            List<Pos> availableMoves = getAvailableMoves();


            // Max, computer's turn 
            if(turn == 0)
            {
                int maxInChild = int.MinValue;
                foreach (var move in availableMoves)
                {
                    BoardState childState = new BoardState(newBoard(move, 'x'), changeTurn(turn), depth + 1, alpha, beta);
                    int childScore = childState.minimax();

                    if (childScore > maxInChild)
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

            return 0;

        }


        // 盘面评估函数
        public int evaluate(char[,] givenBoard)
        {


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

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (board[i, j] == '_')
                    {
                        // 离棋子近的放在候选列表的前列
                        if(hasNeighbor(i, j, 1))
                        {
                            result.Add(new Pos(i, j));
                        }
                        else if(hasNeighbor(i, j, 2))
                        {
                            result.Add(new Pos(i, j));
                        }
                    }
                    
                }
            }

            return result;
        }

        public bool hasNeighbor(int i, int j, int neighborRange)
        {
            Pos up = new Pos(-1, 0);
            Pos down = new Pos(1, 0);
            Pos left = new Pos(0, -1);
            Pos right = new Pos(0, 1);
            Pos upleft = new Pos(-1, -1);
            Pos upright = new Pos(-1, 1);
            Pos downleft = new Pos(1, -1);
            Pos downright = new Pos(1, 1);

            List<Pos> directions = new List<Pos>() { up, down, left, right, upleft, upright, downleft, downright};

            for(int range = 1; range <= neighborRange; range++)
            {
                foreach (var direction in directions)
                {
                    int x = i + direction.x * range;
                    int y = j + direction.y * range;
                    x = x < 0 ? 0 : x;
                    x = x > 14 ? 14 : x;
                    y = y < 0 ? 0 : y;
                    y = y > 14 ? 14 : y;

                    if (board[x,y] != '_')
                    {
                        return true;
                    }
                }
            }
            
            
            return false;
        }

        //  TODO
        public bool checkFinishedAccordingToLastMove(Pos pos)
        {

            return false;
        }

        public List<Pos> checkFinished(char[,] givenBoard)
        {
            List<Pos> winningPath = new List<Pos>();

            // check rows
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (givenBoard[i, j] == '_')
                        continue;
                    for (int k = 1; k < 5; k++)
                    {
                        if (givenBoard[i, j] != givenBoard[i, j + k])
                        {
                            break;
                        }
                        if (k == 4)
                        {
                            Console.WriteLine("{0} is winner.", givenBoard[i, j]);
                            for (int jj = j; jj < j + 5; jj++)
                            {
                                winningPath.Add(new Pos(i, jj));
                                Console.WriteLine("({0}, {1}) ", i, jj);
                            }
                            return winningPath;
                        }

                    }
                }
            }


            // check cols
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (givenBoard[i, j] == '_')
                        continue;

                    for (int k = 1; k < 5; k++)
                    {
                        if (givenBoard[i, j] != givenBoard[i + k, j])
                        {
                            break;
                        }
                        if (k == 4)
                        {
                            Console.WriteLine("{0} is winner.", givenBoard[i, j]);
                            for (int ii = i; ii < i + 5; ii++)
                            {
                                winningPath.Add(new Pos(ii, j));
                                Console.WriteLine("({0}, {1}) ", ii, j);
                            }
                            return winningPath;
                        }
                    }
                }
            }

            // check diagonal \
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (givenBoard[i, j] == '_')
                        continue;
                    for (int k = 1; k < 5; k++)
                    {
                        if (givenBoard[i, j] != givenBoard[i + k, j + k])
                        {
                            break;
                        }
                        if (k == 4)
                        {
                            Console.WriteLine("{0} is winner.", givenBoard[i, j]);
                            for (int offset = 0; offset < 5; offset++)
                            {
                                winningPath.Add(new Pos(i + offset, j + offset));
                                Console.WriteLine("({0}, {1}) ", i + offset, j + offset);
                            }
                            return winningPath;
                        }
                    }
                }
            }

            // check diagonal /
            for (int i = 0; i < 11; i++)
            {
                for (int j = 4; j < 15; j++)
                {
                    if (givenBoard[i, j] == '_')
                        continue;
                    for (int k = 1; k < 5; k++)
                    {
                        if (givenBoard[i, j] != givenBoard[i + k, j - k])
                        {
                            break;
                        }
                        if (k == 4)
                        {
                            Console.WriteLine("{0} is winner.", givenBoard[i, j]);
                            for (int offset = 0; offset < 5; offset++)
                            {
                                winningPath.Add(new Pos(i + offset, j - offset));
                                Console.WriteLine("({0}, {1}) ", i + offset, j - offset);
                            }
                            return winningPath;
                        }
                    }
                }
            }

            for(int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if(board[i, j] == '_')
                    {
                        Console.WriteLine("Not finished.");
                        return winningPath;    //  empty list, not finished;
                    }
                }
            }
            
            winningPath.Add(new Pos(99, 99));  //  Tie
            return winningPath;
        }
    }
}
