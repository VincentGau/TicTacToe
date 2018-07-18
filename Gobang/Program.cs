using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gobang
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.MaxValue;
            if(a < a + 1)
            {
                Console.WriteLine("lalala");
            }
            Console.WriteLine(a);
            Console.WriteLine(a + 1);
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
        }
    }
}
