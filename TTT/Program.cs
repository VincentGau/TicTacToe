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
            foreach(var i in bs.getAvailableMoves())
            {
                Console.WriteLine("{0} -  {1}", i.x, i.y);
            }

            char w = ' ';
            bs.checkFinish(out w);
            Console.WriteLine(w);

            bs.drawBoard();

            bs.updateBoard(new Pos(1, 1), 'o');
            bs.drawBoard();
        }
    }
}
