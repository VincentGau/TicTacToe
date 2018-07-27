using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakuGoCmd
{
    class Helper
    {
        // 棋盘尺寸
        public const int ROW = 15;

        public const int searchDepth = 4;

        public const int MOVESIZE = 5;

        // 成五
        public const int FIVE = 1000000;

        // 活四
        public const int FOUR = 100000;

        public const int THREE = 50000;

        public const int BLOCK_FOUR = 0;

        public const int TWO = 0;

        public static char AIMark = 'x';

        public static char playerMark = 'o';

    }
}
