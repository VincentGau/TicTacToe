using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HakuGo
{
    

    public class GoCore
    {
        
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

        public void updateBoard(Pos p, char c)
        {
            if (board[p.x, p.y] == '_')
            {
                board[p.x, p.y] = c;
            }
            else
            {
                Console.WriteLine("Invalid move");
            }
        }

        public bool checkFinished(char[,] givenBoard)
        {
            int count = 0;

            // check rows
            for(int i = 0; i < 15; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if (givenBoard[i, j] == '_')
                        continue;
                    for(int k = 0; k < 5; k++)
                    {
                        if (givenBoard[i,j] != givenBoard[i, j + k])
                        {
                            break;
                        }
                        if(k == 4)
                        {
                            Console.WriteLine("{0} is winner.", givenBoard[i, j]);
                            return true;
                        }
                        
                    }
                }
            }



            return false;
        }
    }
}