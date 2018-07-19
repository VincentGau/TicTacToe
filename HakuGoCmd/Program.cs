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
            Console.WriteLine(winningPath.Count);
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

        public List<Pos> getAvailableMoves()
        {
            List<Pos> result = new List<Pos>();
            
            return result;
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
            for(int i = 0; i < 11; i++)
            {
                for(int j = 0; j < 11; j++)
                {
                    if (givenBoard[i, j] == '_')
                        continue;
                    for(int k = 1; k < 5; k++)
                    {
                        if(givenBoard[i,j] != givenBoard[i+k, j + k])
                        {
                            break;
                        }
                        if (k == 4)
                        {
                            Console.WriteLine("{0} is winner.", givenBoard[i, j]);
                            for (int offset = 0; offset<5; offset++)
                            {
                                winningPath.Add(new Pos(i + offset, j + offset));
                                Console.WriteLine("({0}, {1}) ", i+offset, j+offset);
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


            Console.WriteLine("Not finished.");
            return winningPath;
        }
    }
}
