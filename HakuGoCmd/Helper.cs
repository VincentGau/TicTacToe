using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakuGoCmd
{
    public class Helper
    {
        // 棋盘尺寸
        public const int ROW = 15;

        public const int searchDepth = 6;

        public const int MOVESIZE = 5;


        /// <summary>
        /// 成五
        /// </summary>
        public const int LEVEL1 = 10000;

        /// <summary>
        ///  活四 双冲四 冲四活三
        /// </summary>
        public const int LEVEL2 = 5000;

        /// <summary>
        ///  双活三
        /// </summary>
        public const int LEVEL3 = 3000;


        /// <summary>
        /// 活三眠三
        /// </summary>
        public const int LEVEL4 = 2000;

        /// <summary>
        /// 冲四
        /// </summary>
        public const int LEVEL5 = 1000;

        /// <summary>
        /// 活三
        /// </summary>
        public const int LEVEL6 = 500;

        /// <summary>
        /// 双活二
        /// </summary>
        public const int LEVEL7 = 400;

        /// <summary>
        /// 眠三
        /// </summary>
        public const int LEVEL8 = 300;

        /// <summary>
        /// 活二
        /// </summary>
        public const int LEVEL9 = 200;

        /// <summary>
        /// 冲二
        /// </summary>
        public const int LEVEL10 = 100;

        /// <summary>
        /// 活一
        /// </summary>
        public const int LEVEL11 = 70;

        /// <summary>
        /// 冲一
        /// </summary>
        public const int LEVEL12 = 50;


        
        public static char AIMark = 'x';

        public static char playerMark = 'o';

        public static char emptyMark = '_';

    }
}
