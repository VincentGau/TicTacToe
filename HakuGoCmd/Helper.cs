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

        public const int searchDepth = 1;

        public const int MOVESIZE = 2;

        

        /// <summary>
        /// 成五
        /// 活四 双冲四 冲四活三
        /// 双活三
        /// 活三眠三
        /// 冲四
        /// 活三
        /// 双活二
        /// 眠三
        /// 活二
        /// 冲二
        /// </summary>

        // 成五
        public const int LEVEL1 = 10000;

        // 活四 双冲四 冲四活三
        public const int LEVEL2 = 5000;

        // 双活三
        public const int LEVEL3 = 3000;

        // 活三眠三
        public const int LEVEL4 = 2000;

        // 冲四
        public const int LEVEL5 = 1000;

        // 活三
        public const int LEVEL6 = 400;

        // 双活二
        public const int LEVEL7 = 500;

        // 眠三
        public const int LEVEL8 = 300;

        // 活二
        public const int LEVEL9 = 200;

        // 冲二
        public const int LEVEL10 = 100;



        public const int BLOCK_TWO = 100;

        public static char AIMark = 'x';

        public static char playerMark = 'o';

        public static char emptyMark = '_';

    }
}
