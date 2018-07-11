using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardState bs = new BoardState();
            bs.drawBoard();
            Console.WriteLine(bs.getScore() ); 
            bs.move();

            while (true)
            {
                if (!bs.checkFinish(out char w))
                {
                    Console.WriteLine("your turn now: ");
                    bs.updateBoard(bs.getInputPos(), 'o');
                    bs.drawBoard();
                    Console.WriteLine(bs.getScore());
                    bs.move();
                }
                else
                {
                    if (w == 'o')
                    {
                        Console.WriteLine("you win.");
                    }
                    if (w == 'x')
                    {
                        Console.WriteLine("you lose.");
                    }
                    if (w == 't')
                    {
                        Console.WriteLine("Tie");
                    }
                    break;
                }
            }

            //foreach(var i in bs.getAvailableMoves())
            //{
            //    Console.WriteLine("{0} -  {1}", i.x, i.y);
            //}

            //char w = ' ';
            //bs.checkFinish(out w);
            //Console.WriteLine(w);

            //bs.drawBoard();

            //bs.updateBoard(new Pos(1, 1), 'o');
            //bs.drawBoard();
        }

        static void playerMove()
        {

        }
    }
}
