using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3] { { '_', '_', '_' }, { '_', '_', '_' }, { '_', '_', '_' } };
        static void Main(string[] args)
        {
            while (true)
            {
                if (win('x'))
                {
                    Console.WriteLine("you win.");
                    break;
                }

                if (win('o'))
                {
                    Console.WriteLine("you lose.");
                    break;
                }
                
                int x, y;
                getXY(out x, out y);

                updateBoard(x, y, 'x');

                drawBoard(board);
            }

            
        }


        /// <summary>
        /// get move location
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        static void getXY(out int x, out int y)
        {
            string s = Console.ReadLine();
            string[] result = s.Split(' ');

            x = Convert.ToInt32(result[0]);
            y = Convert.ToInt32(result[1]);
        }

        static void drawBoard(char[,] board)
        {
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }                
        }


        static void updateBoard(int i, int j, char c)
        {
            if(board[i, j] != '_')
            {
                Console.WriteLine("Invalid move. Please enter again.");
                string s = Console.ReadLine();
                string[] result = s.Split(' ');

                updateBoard(Convert.ToInt32(result[0]), Convert.ToInt32(result[1]), 'x');
            }
                
            else
                board[i, j] = c;
        }

        static bool win(char c)
        {
            //check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == c && board[i, 1] == c && board[i, 2] == c)
                    return true;
            }


            //check cols
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == c && board[1, i] == c && board[2, i] == c)
                    return true;
            }

            //check diagonal
            if (board[0, 0] == c && board[1, 1] == c && board[2, 2] == c)
                return true;
            if (board[2, 0] == c && board[1, 1] == c && board[0, 2] == c)
                return true;
            return false;
        }

        static int evaluate(char[,] board)
        {
            int value = 0;


            return value;
        }

    }
}
