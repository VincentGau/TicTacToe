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
        public const int FIVE = 10000;

        // 活四
        public const int FOUR = 5000;

        // 双活三
        public const int DOUBLE_THREE = 3000;

        // 冲四
        public const int BLOCK_FOUR = 2000;

        // 活三
        public const int THREE = 1000;

        // 眠三
        public const int BLOCK_THREE = 400;

        // 活二
        public const int TWO = 500;

        public const int BLOCK_TWO = 100;

        public static char AIMark = 'x';

        public static char playerMark = 'o';

        public static char emptyMark = '_';

    }
}
