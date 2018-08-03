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
                { '_', '_', '_', '_', '_', 'o', 'o', 'o', '_', '_', 'o', 'x', 'o', 'o', '_', },// 1
                { 'x', '_', '_', '_', '_', '_', '_', '_', 'o', '_', '_', '_', '_', '_', '_', },// 2
                { 'x', 'x', '_', '_', '_', '_', '_', 'o', '_', '_', '_', '_', '_', '_', '_', },// 3
                { 'x', '_', 'x', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 4
                { 'o', '_', '_', 'x', '_', 'o', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 5
                { 'x', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 6
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

            testBoard = new char[15, 15] {
                { '_', '_', '_', '_', 'x', 'o', 'o', 'o', 'o', 'x', 'o', 'x', 'o', 'o', '_', },// 1
                { '_', '_', '_', '_', '_', '_', '_', '_', 'o', '_', '_', '_', '_', '_', '_', },// 2
                { 'x', 'x', '_', '_', '_', '_', '_', 'o', '_', '_', '_', '_', '_', '_', '_', },// 3
                { 'x', '_', 'x', '_', '_', '_', 'x', '_', '_', '_', '_', '_', '_', '_', '_', },// 4
                { 'o', '_', '_', 'x', '_', 'o', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 5
                { 'x', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 6
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

            testBoard = new char[15, 15] {
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 1
                { '_', '_', '_', '_', '_', '_', 'x', '_', '_', '_', '_', '_', '_', '_', '_', },// 2
                { '_', '_', '_', '_', 'x', 'o', 'o', '_', '_', '_', '_', '_', '_', '_', '_', },// 3
                { '_', '_', '_', '_', 'x', '_', 'o', '_', '_', '_', '_', '_', '_', '_', '_', },// 4
                { '_', '_', '_', '_', '_', 'x', 'o', 'o', '_', '_', '_', '_', '_', '_', '_', },// 5
                { '_', '_', '_', '_', 'x', '_', 'o', '_', '_', '_', '_', '_', '_', '_', '_', },// 6
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

            bs.board = testBoard;
            bs.drawBoard();

            Pos ppp = new Pos(3,7);
            int vvvalue = bs.evaluateOneSide(testBoard, ppp, Helper.playerMark);
            vvvalue = bs.evaluate(testBoard, new Pos(0, 9));

            // <winningPath> store the five positions if one has won;
            // empty is the game is not finished yet;
            // store Pos(99,99) is game is over and there is a tie;

            //List<Pos> winningPath = new List<Pos>();
            //winningPath = bs.checkFinished(testBoard);

            
            //if (bs.hasNeighbor(7, 0, 2))
            //{
            //    Console.WriteLine("has neighbor.");
            //}
            //bs.drawBoard();


            
            Console.WriteLine(bs.minimax());
            bs.move();

            while (true)
            {
                // <winningPath> store the five positions if one has won;
                // empty is the game is not finished yet;
                // store Pos(99,99) is game is over and there is a tie;
                var winningPath = bs.checkFinished(bs.board);
                // not finished
                if (!winningPath.Any())
                {
                    Console.WriteLine("your turn now: ");
                    Pos inputPos = bs.getInputPos();
                    bs.updateBoard(inputPos, Helper.playerMark);
                    bs.drawBoard();
                    Console.WriteLine(bs.minimax());
                    bs.move();
                }
                else
                {
                    if (winningPath[0].x == 99)
                    {
                        Console.WriteLine("Tie");
                        break;
                    }
                    if (bs.board[winningPath[0].x, winningPath[0].y] == Helper.AIMark)
                    {
                        Console.WriteLine("You lose");
                        break;
                    }
                    if (bs.board[winningPath[0].x, winningPath[0].y] == Helper.playerMark)
                    {
                        Console.WriteLine("You win");
                        break;
                    }
                }
            }
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


        /// <summary>
        /// 接受输入一个坐标
        /// </summary>
        /// <returns></returns>
        public Pos getInputPos()
        {
            string s = Console.ReadLine();
            string[] result = s.Split(' ');

            return new Pos(Convert.ToInt32(result[0]), Convert.ToInt32(result[1]));
        }

        public void drawBoard()
        {
            Console.Write("  ");
            for (int i = 0; i < 15; i++)
            {
                Console.Write(string.Format("{0, 2}", i % 10));
            }
            Console.WriteLine();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write(string.Format("{0, 2} ", i));
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

            depth = 0;
        }

        public int minimax()
        {
            List<Pos> result = checkFinished(board);
            if (result.Count == 5)
            {
                if (board[result[0].x, result[0].y] == 'x')
                {
                    //Console.WriteLine("winner is x.");
                    return Helper.LEVEL1 - depth;
                }

                if (board[result[0].x, result[0].y] == 'o')
                {
                    //Console.WriteLine("winner is o.");
                    return -Helper.LEVEL1 + depth;
                }
            }

            if (result.Count == 1)
            {
                //Console.WriteLine("Tie.");
                return 0;
            }

            List<Pos> availableMoves = getAvailableMoves();
            //availableMoves = shrinkAvailableMoves(availableMoves, Helper.MOVESIZE);

            // 盘面的评价函数如何定义：当前局面，黑子落下所能获得的最大分数，白子落下所能获得的最小分数

            // Max, computer's turn 
            if (turn == 0)
            {
                availableMoves = shrinkAvailableMoves(availableMoves, Helper.MOVESIZE, Helper.AIMark);
                int maxInChild = int.MinValue;
                foreach (var move in availableMoves)
                {
                    int childScore;
                    BoardState childState = new BoardState(newBoard(move, Helper.AIMark), changeTurn(turn), depth + 1, alpha, beta);
                    if (depth >= Helper.searchDepth || checkFinished(childState.board).Count == 5)
                    {
                        //使用新的评估函数
                        //childScore = evaluate(board, move) - depth;
                        //childScore = evaluateOneSide(board, move, Helper.playerMark) - depth;
                        childScore = evaluateBoard(childState.board);

                        nextMove = childState;
                        //return childScore;
                    }
                    else
                    {
                        childScore = childState.minimax();
                    }


                    if (childScore > maxInChild)
                    {
                        maxInChild = childScore;
                        alpha = maxInChild;
                        nextMove = childState;
                    }

                    if (alpha >= beta)
                        break;
                }
                return maxInChild;
            }

            //Min, player's turn
            else if (turn == 1)
            {
                availableMoves = shrinkAvailableMoves(availableMoves, Helper.MOVESIZE, Helper.playerMark);
                int minInChild = int.MaxValue;
                foreach (var move in availableMoves)
                {
                    BoardState childState = new BoardState(newBoard(move, Helper.playerMark), changeTurn(turn), depth + 1, alpha, beta);
                    int childScore;
                    if (depth >= Helper.searchDepth || checkFinished(childState.board).Count == 5)
                    {
                        //使用新的评估函数
                        //childScore = -evaluate(board, move) + depth;
                        //childScore = evaluateOneSide(board, move, Helper.AIMark) + depth;
                        childScore = evaluateBoard(childState.board);
                        
                        nextMove = childState;
                        //return childScore;
                    }

                    else
                    {
                        childScore = childState.minimax();
                    }


                    if (childScore < minInChild)
                    {
                        minInChild = childScore;
                        beta = minInChild;
                        nextMove = childState;
                    }

                    if (alpha >= beta)
                        break;
                }

                return minInChild;
            }

            return 0;

        }

        // DEPRECATED 盘面评估函数
        public int evaluate(char[,] givenBoard)
        {
            Pos up = new Pos(-1, 0);
            Pos down = new Pos(1, 0);
            Pos left = new Pos(0, -1);
            Pos right = new Pos(0, 1);
            Pos upleft = new Pos(-1, -1);
            Pos upright = new Pos(-1, 1);
            Pos downleft = new Pos(1, -1);
            Pos downright = new Pos(1, 1);

            // 向八个方向检查盘面
            List<Pos> directions = new List<Pos>() { up, down, left, right, upleft, upright, downleft, downright };


            // 成五
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    foreach (var direction in directions)
                    {
                        int x = i + direction.x * 5;
                        int y = j + direction.y * 5;
                        if (x < 0 || x > 14 || y < 0 || y > 14)
                        {
                            continue;
                        }

                        for (int range = 1; range < 5; range++)
                        {
                            if (givenBoard[i, j] != givenBoard[i + direction.x * range, j + direction.y * range])
                            {
                                break;
                            }
                            if (range == 4)
                            {
                                if (givenBoard[i, j] == Helper.AIMark)
                                    return Helper.LEVEL1;
                                if (givenBoard[i, j] == Helper.playerMark)
                                    return -Helper.LEVEL1;
                            }
                        }
                    }
                }
            }

            // 活四 连续六个位置中，两端为空，其余四个位置为相同棋子
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    foreach (var direction in directions)
                    {
                        // 如果延伸段超过边界 则不可能再有活四 
                        int x = i + direction.x * 5;
                        int y = j + direction.y * 5;
                        if (x < 0 || x > 14 || y < 0 || y > 14)
                        {
                            continue;
                        }
                        if (givenBoard[i, j] == '_' && givenBoard[i + direction.x * 5, j + direction.y * 5] == '_')
                        {
                            for (int range = 2; range <= 4; range++)
                            {
                                if (givenBoard[i + direction.x, j + direction.y] != givenBoard[i + direction.x * range, j + direction.y * range])
                                    break;

                                if (range == 4)
                                {
                                    if (givenBoard[i + direction.x, j + direction.y] == Helper.AIMark)
                                        return Helper.LEVEL2;
                                    if (givenBoard[i + direction.x, j + direction.y] == Helper.playerMark)
                                        return -Helper.LEVEL2;
                                }
                            }

                        }
                    }

                }
            }


            // 活三 _xxx__ __xxx_ _xx_x _x_xx_  连续六个位置中，两端为空，中间四个位置有三个是其中一方的棋子，一个是空；
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    foreach (var direction in directions)
                    {
                        // 延伸段超过边界 如果有活三已经在前一步计算过 
                        int x = i + direction.x * 5;
                        int y = j + direction.y * 5;
                        if (x < 0 || x > 14 || y < 0 || y > 14)
                        {
                            break;
                        }

                        int countAI = 0;
                        int countPL = 0;
                        if (givenBoard[i, j] == '_' && givenBoard[i + direction.x * 5, j + direction.y * 5] == '_')
                        {
                            for (int range = 1; range <= 4; range++)
                            {

                                if (givenBoard[i + direction.x * range, j + direction.y * range] == Helper.AIMark)
                                {
                                    countAI++;
                                }

                                else if (givenBoard[i + direction.x * range, j + direction.y * range] == Helper.AIMark)
                                {
                                    countPL++;
                                }

                                if (countAI == 3 && countPL == 0)
                                {
                                    return Helper.LEVEL5;
                                }

                                if (countPL == 3 && countAI == 0)
                                {
                                    return -Helper.LEVEL5;
                                }
                            }


                        }
                    }

                }
            }

            // 冲四 连续五个位置有四个是一方棋子，剩下一个为空
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    foreach (var direction in directions)
                    {
                        // 延伸段超过边界 如果有冲四已经在前一步计算
                        int x = i + direction.x * 5;
                        int y = j + direction.y * 5;
                        if (x < 0 || x > 14 || y < 0 || y > 14)
                        {
                            break;
                        }

                        int countAI = 0;
                        int countPL = 0;
                        if (givenBoard[i, j] == '_' && givenBoard[i + direction.x * 5, j + direction.y * 5] == '_')
                        {
                            for (int range = 1; range <= 4; range++)
                            {

                                if (givenBoard[i + direction.x * range, j + direction.y * range] == Helper.AIMark)
                                {
                                    countAI++;
                                }

                                else if (givenBoard[i + direction.x * range, j + direction.y * range] == Helper.AIMark)
                                {
                                    countPL++;
                                }

                                if (countAI == 3 && countPL == 0)
                                {
                                    return Helper.LEVEL5;
                                }

                                if (countPL == 3 && countAI == 0)
                                {
                                    return -Helper.LEVEL5;
                                }
                            }


                        }
                    }

                }
            }

            return 0;
        }

        /// <summary>
        /// 评估落子点得分，考虑攻防
        /// </summary>
        /// <param name="givenBoard"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public int evaluate(char[,] givenBoard, Pos pos)
        {
            int value1 = evaluateOneSide(givenBoard, pos, Helper.AIMark);
            int value2 = evaluateOneSide(givenBoard, pos, Helper.playerMark);
            return value1 - value2;
        }


        /// <summary>
        /// 局面评分定义成所有棋子得分之和，棋子得分AI方为正，玩家方为负
        /// </summary>
        /// <param name="givenBoard"></param>
        /// <returns></returns>
        public int evaluateBoard(char[,] givenBoard)
        {
            int AIScore = 0;
            int playScore = 0;
            for(int i = 0; i < 15; i++)
            {
                for(int j = 0; j < 15; j++)
                {
                    if(givenBoard[i, j] != Helper.emptyMark)
                    {
                        int value = evaluatePos(givenBoard, new Pos(i, j));
                        if(value < 0)
                        {
                            AIScore += value;
                        }
                        if(value > 0)
                        {
                            playScore += value;
                        }
                    }
                }
            }

            return AIScore + playScore;
        }

        /// <summary>
        /// 计算盘面上某一点的分数
        /// </summary>
        /// <param name="givenBoard"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public int evaluatePos(char[,] givenBoard, Pos pos)
        {
            char mark = givenBoard[pos.x, pos.y];
            if(mark == Helper.emptyMark)
            {
                return 0;
            }

            return evaluateOneSide(givenBoard, pos, mark);
        }

        /// <summary>
        /// 在pos 处落子mark 的得分
        /// </summary>
        /// <param name="givenBoard"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public int evaluateOneSide(char[,] givenBoard, Pos pos, char mark)
        {
            Pos up = new Pos(-1, 0);
            Pos down = new Pos(1, 0);
            Pos left = new Pos(0, -1);
            Pos right = new Pos(0, 1);
            Pos upleft = new Pos(-1, -1);
            Pos upright = new Pos(-1, 1);
            Pos downleft = new Pos(1, -1);
            Pos downright = new Pos(1, 1);

            int returnValue = 0;

            // 向八个方向检查盘面
            //List<Pos> directions = new List<Pos>() { up, down, left, right, upleft, upright, downleft, downright };
            List<Pos> directions = new List<Pos>() { up, left, upleft, upright };

            int five = 0;
            int four = 0;
            int blockfour = 0;
            int three = 0;
            int blockthree = 0;
            int two = 0;
            int blocktwo = 0;
            int one = 0;
            int blockone = 0;

            foreach (var direction in directions)
            {
                // 以pos 为中心向两方向扩展，碰到的第一个不是mark 的位置的落子情况
                char leftOne, rightOne;

                // 标志位 扩展两边的时候是否碰到边界 碰到边界不继续扩展
                bool leftBound = false, rightBound = false;

                // 标志位 扩展两边的时候是否碰到对方棋子 碰到对方棋子不继续扩展
                bool leftEnemy = false, rightEnemy = false;

                // 中心点向两边延伸一直是同颜色棋子的最远的位置
                int leftEnd = 0, rightEnd = 0;

                // 标志位 扩展两边的时候是否碰到空白 碰到空白可以继续扩展
                int leftEmpty = 0, rightEmpty = 0;

                // 计数 以pos 为中心向两边扩展，连续都是当前棋子的个数
                int leftCount = 0, rightCount = 0;

                // 计数 扩展的时候碰到空白 继续扩展碰到当前mark 的个数
                int continueCountLeft = 0, continueCountRight = 0;

                // 向一个方向扩展
                for(int i = 1; i < 5; i++)
                {
                    // 越界 跳出循环
                    if(pos.x - direction.x * i < 0 || pos.y - direction.y * i < 0 || pos.x - direction.x * i > 14 || pos.y - direction.y * i > 14)
                    {
                        leftBound = true;
                        break;
                    }

                    // 扩展点仍是mark
                    if(givenBoard[pos.x - direction.x * i, pos.y - direction.y * i] == mark)
                    {
                        // 未碰到过空位
                        if(leftEmpty == 0)
                        {
                            leftCount++;
                            leftEnd = i;
                            continue;
                        }
                        else
                        {
                            continueCountLeft++;
                            continue;
                        }
                    }
                    // 扩展点不是mark，是空或对手
                    else
                    {
                        leftOne = givenBoard[pos.x - direction.x * i, pos.y - direction.y * i];
                        if(leftOne == changeMark(mark))
                        {
                            leftEnemy = true;
                            break;
                        }
                        if( leftOne == Helper.emptyMark )
                        {
                            leftEmpty++;
                            continue;
                        }
                    }
                }

                // 向另一个方向扩展
                for (int i = 1; i < 5; i++)
                {
                    if (pos.x + direction.x * i > 14 || pos.y + direction.y * i > 14 || pos.x + direction.x * i  < 0 || pos.y + direction.y * i < 0)
                    {
                        rightBound = true;
                        break;
                    }

                    if (givenBoard[pos.x + direction.x * i, pos.y + direction.y * i] == mark)
                    {
                        if(rightEmpty == 0)
                        {
                            rightCount++;
                            rightEnd = i;
                            continue;
                        }
                        else
                        {
                            continueCountRight++;
                            continue;
                        }
                        
                    }
                    else
                    {
                        rightOne = givenBoard[pos.x + direction.x * i, pos.y + direction.y * i];
                        if(rightOne == changeMark(mark))
                        {
                            rightEnemy = true;
                            break;
                        }
                        if(rightOne == Helper.emptyMark)
                        {
                            rightEmpty++;
                            continue;
                        }
                        break;
                    }
                }

                // 除了中心点 还有连续四个以上棋子，成五
                if(leftCount + rightCount >= 4)
                {
                    if(mark == Helper.AIMark)
                        return Helper.LEVEL1;
                    if(mark == Helper.playerMark)
                        return -Helper.LEVEL1;
                }

                // 四连 可能产生活四和冲四
                else if (leftCount + rightCount == 3)
                {
                    // 四连 并且两边都有空白 活四
                    if (leftEmpty >0 && rightEmpty>0)
                    {
                        four++;
                    }

                    // 冲四 四连的一边有空另一边没有空
                    else if ((leftEmpty == 0 && rightEmpty > 0) || (leftEmpty > 0 && rightEmpty == 0))
                    {
                        blockfour++;
                    }
                }

                // 三连
                else if(leftCount + rightCount == 2)
                {
                    // 活三 +OOO++ leftempty 和rightempty 都大于0，表示紧跟的两边都为空（如果紧跟边界或对方棋子，则empty == 0；如果紧跟己方棋子，左右count 和会大于2；）；
                    //9个位置中靠近中间的一段肯定是 _xxx_， 那么只要这一段的左右有一个空即可组成活三
                    if (leftEmpty > 0 && rightEmpty > 0)
                    {
                        if (givenBoard[pos.x - direction.x * (leftEnd + 1), pos.y - direction.y * (leftEnd + 1)] != Helper.emptyMark ||
                            givenBoard[pos.x + direction.x * (rightEnd + 1), pos.y + direction.y * (rightEnd + 1)] != Helper.emptyMark)
                        {
                            Console.WriteLine("P001 Some really bad happened !!!");
                            return -1;
                        }
                        int leftX = pos.x - direction.x * (leftEnd + 2);
                        int leftY = pos.y - direction.y * (leftEnd + 2);
                        int rightX = pos.x + direction.x * (rightEnd + 2);
                        int rightY = pos.y + direction.y * (rightEnd + 2);

                        //+OOO+ 这一段的至少一侧有空 则组成活三；否则组成眠三（两侧都是不可落子点）；
                        if ((isLeagal(leftX) && isLeagal(leftY) && givenBoard[leftX, leftY] == Helper.emptyMark) || 
                            (isLeagal(rightX) && isLeagal(rightY) && givenBoard[rightX, rightY] == Helper.emptyMark))
                        {
                            three++;
                        }
                        else
                        {
                            blockthree++;
                        }
                        
                    }

                    // 冲四和眠三 只要其中一方向空一个之后出现己方棋子，即可组成冲四; 两个空则组成眠三
                    // leftEmpty 和rightEmpty不同时大于0, 表示起码其中一边立刻碰到边界或对方棋子
                    // 左侧立刻碰到边界或对方棋子，右侧是 空白+己方棋子 即可组成冲四
                    else if ( leftEmpty == 0 && rightEmpty > 0)
                    {
                        int rightX1 = pos.x + direction.x * (rightEnd + 1);
                        int rightY1 = pos.y + direction.y * (rightEnd + 1);
                        int rightX2 = pos.x + direction.x * (rightEnd + 2);
                        int rightY2 = pos.y + direction.y * (rightEnd + 2);

                        if(isLeagal(rightX1) && isLeagal(rightX2) && isLeagal(rightY1) && isLeagal(rightY2))
                        {
                            // 冲四 XOOO+O
                            if(givenBoard[rightX1, rightY1] == Helper.emptyMark && givenBoard[rightX2, rightY2] == mark)
                            {
                                blockfour++;
                            }

                            // 眠三 XOOO++
                            else if(givenBoard[rightX1, rightY1] == Helper.emptyMark && givenBoard[rightX2, rightY2] == Helper.emptyMark)
                            {
                                blockthree++;
                            }
                        }
                    }


                    else if (rightEmpty == 0 && leftEmpty > 0)
                    {
                        int leftX1 = pos.x - direction.x * (leftEnd + 1);
                        int leftY1 = pos.y - direction.y * (leftEnd + 1);
                        int leftX2 = pos.x - direction.x * (leftEnd + 2);
                        int leftY2 = pos.y - direction.y * (leftEnd + 2);

                        if (isLeagal(leftX1) && isLeagal(leftX2) && isLeagal(leftY1) && isLeagal(leftY2))
                        {
                            // 冲四
                            if(givenBoard[leftX1, leftY1] == Helper.emptyMark && givenBoard[leftX2, leftY2] == mark)
                            {
                                blockfour++;
                            }

                            // 眠三
                            else if(givenBoard[leftX1, leftY1] == Helper.emptyMark && givenBoard[leftX2, leftY2] == Helper.emptyMark)
                            {
                                blockthree++;
                            }
                        }                        
                    }
                }


                // 二连
                else if(leftCount + rightCount == 1)
                {
                    // 活三和眠三 +OO+
                    if(leftEmpty > 0 && rightEmpty > 0)
                    {

                        int leftX2 = pos.x - direction.x * (leftEnd + 2);
                        int leftY2 = pos.y - direction.y * (leftEnd + 2);
                        int rightX2 = pos.x + direction.x * (rightEnd + 2);
                        int rightY2 = pos.y + direction.y * (rightEnd + 2);

                        int leftX3 = pos.x - direction.x * (leftEnd + 3);
                        int leftY3 = pos.y - direction.y * (leftEnd + 3);
                        int rightX3 = pos.x + direction.x * (rightEnd + 3);
                        int rightY3 = pos.y + direction.y * (rightEnd + 3);


                        // 活三 +OO+O+ +O+OO+ 二连一侧为空 另一侧为 空+己方+空
                        if ((isLeagal(leftX2) && isLeagal(leftY2) && givenBoard[leftX2, leftY2] == mark && isLeagal(leftX3) && isLeagal(leftY3) && givenBoard[leftX3, leftY3] == Helper.emptyMark) ||
                            (isLeagal(rightX2) && isLeagal(rightY2) && givenBoard[rightX2, rightY2] == mark && isLeagal(rightX3) && isLeagal(rightY3) && givenBoard[rightX3, rightY3] == Helper.emptyMark))
                        {
                            three++;
                        }

                        // 眠三 XO+OO+ 二连一侧为空，另一侧为 空+己方+壁垒
                        if((isLeagal(leftX2) && isLeagal(leftY2) && givenBoard[leftX2, leftY2] == mark && isBarrier(givenBoard, new Pos(leftX3, leftY3), mark)) ||
                            (isLeagal(rightX2) && isLeagal(rightY2) && givenBoard[rightX2, rightY2] == mark && isBarrier(givenBoard, new Pos(rightX3, rightY3), mark)))
                        {
                            blockthree++;
                        }

                        // 活二 ++OO++ 二连两侧均有两个连续空位
                        if(isLeagal(leftX2) && isLeagal(leftY2) && isLeagal(rightX2) && isLeagal(rightY2) && givenBoard[leftX2, leftY2] == Helper.emptyMark && givenBoard[rightX2, rightY2] == Helper.emptyMark)
                        {
                            two++;
                        }

                    }

                    // 冲四和眠三 
                    else if (leftEmpty == 0 && rightEmpty > 0)
                    {
                        int rightX1 = pos.x + direction.x * (rightEnd + 1);
                        int rightY1 = pos.y + direction.y * (rightEnd + 1);
                        int rightX2 = pos.x + direction.x * (rightEnd + 2);
                        int rightY2 = pos.y + direction.y * (rightEnd + 2);
                        int rightX3 = pos.x + direction.x * (rightEnd + 3);
                        int rightY3 = pos.y + direction.y * (rightEnd + 3);

                        // 冲四 OO+OO 二连的一侧为壁垒，另一侧为 空+己方+己方
                        if (isLeagal(rightX1) && isLeagal(rightX2) && isLeagal(rightY1) && isLeagal(rightY2) && isLeagal(rightX3) && isLeagal(rightY3) &&
                            givenBoard[rightX1, rightY1] == Helper.emptyMark && givenBoard[rightX2, rightY2] == mark && givenBoard[rightX3, rightY3] == mark)
                        {
                            blockfour++;
                        }

                        // 眠三 XOO+O+  一侧为壁垒 另一侧为 空+己方+空
                        else if (isLeagal(rightX1) && isLeagal(rightX2) && isLeagal(rightY1) && isLeagal(rightY2) && isLeagal(rightX3) && isLeagal(rightY3) &&
                            givenBoard[rightX1, rightY1] == Helper.emptyMark && givenBoard[rightX2, rightY2] == mark && givenBoard[rightX3, rightY3] == Helper.emptyMark)
                        {
                            blockthree++;
                        }

                        // 眠三 XOO++O  一侧为壁垒 另一侧为 空+空+己方
                        else if (isLeagal(rightX1) && isLeagal(rightX2) && isLeagal(rightY1) && isLeagal(rightY2) && isLeagal(rightX3) && isLeagal(rightY3) &&
                            givenBoard[rightX1, rightY1] == Helper.emptyMark && givenBoard[rightX2, rightY2] == Helper.emptyMark && givenBoard[rightX3, rightY3] == mark)
                        {
                            blockthree++;
                        }

                        // 眠二 XOO+++ 二连一侧为壁垒，另一侧为三个空位
                        else if (isLeagal(rightX3) && isLeagal(rightY3) && givenBoard[rightX1, rightY1] == Helper.emptyMark && givenBoard[rightX2, rightY2] == Helper.emptyMark && givenBoard[rightX3, rightY3] == Helper.emptyMark)
                        {
                            blocktwo++;
                        }
                    }

                    // 冲四 OO+OO 二连的一侧为壁垒，另一侧为 空+己方+己方
                    else if (rightEmpty == 0 && leftEmpty > 0)
                    {
                        int leftX1 = pos.x - direction.x * (leftEnd + 1);
                        int leftY1 = pos.y - direction.y * (leftEnd + 1);
                        int leftX2 = pos.x - direction.x * (leftEnd + 2);
                        int leftY2 = pos.y - direction.y * (leftEnd + 2);
                        int leftX3 = pos.x - direction.x * (leftEnd + 3);
                        int leftY3 = pos.y - direction.y * (leftEnd + 3);

                        // 冲四
                        if (isLeagal(leftX1) && isLeagal(leftX2) && isLeagal(leftY1) && isLeagal(leftY2) && isLeagal(leftX3) && isLeagal(leftY3) &&
                            givenBoard[leftX1, leftY1] == Helper.emptyMark && givenBoard[leftX2, leftY2] == mark && givenBoard[leftX3, leftY3] == mark)
                        {
                            blockfour++;
                        }

                        // 眠三 XOO+O+  一侧为壁垒 另一侧为 空+己方+空
                        else if (isLeagal(leftX1) && isLeagal(leftX2) && isLeagal(leftY1) && isLeagal(leftY2) && isLeagal(leftX3) && isLeagal(leftY3) &&
                            givenBoard[leftX1, leftY1] == Helper.emptyMark && givenBoard[leftX2, leftY2] == mark && givenBoard[leftX3, leftY3] == Helper.emptyMark)
                        {
                            blockthree++;
                        }

                        // 眠三 XOO++O  一侧为壁垒 另一侧为 空+空+己方
                        else if (isLeagal(leftX1) && isLeagal(leftX2) && isLeagal(leftY1) && isLeagal(leftY2) && isLeagal(leftX3) && isLeagal(leftY3) &&
                            givenBoard[leftX1, leftY1] == Helper.emptyMark && givenBoard[leftX2, leftY2] == Helper.emptyMark && givenBoard[leftX3, leftY3] == mark)
                        {
                            blockthree++;
                        }

                        // 眠二 XOO+++ 二连一侧为壁垒，另一侧为三个空位
                        else if (isLeagal(leftX3) && isLeagal(leftY3) &&
                            givenBoard[leftX1, leftY1] == Helper.emptyMark && givenBoard[leftX2, leftY2] == Helper.emptyMark && givenBoard[leftX3, leftY3] == Helper.emptyMark)
                        {
                            blocktwo++;
                        }
                    }

                }

                // 当前位置左右都没有相同棋子
                else if (leftCount + rightCount == 0)
                {
                    int leftX1 = pos.x - direction.x * (leftEnd + 1);
                    int leftY1 = pos.y - direction.y * (leftEnd + 1);
                    int leftX2 = pos.x - direction.x * (leftEnd + 2);
                    int leftY2 = pos.y - direction.y * (leftEnd + 2);
                    int leftX3 = pos.x - direction.x * (leftEnd + 3);
                    int leftY3 = pos.y - direction.y * (leftEnd + 3);
                    int leftX4 = pos.x - direction.x * (leftEnd + 4);
                    int leftY4 = pos.y - direction.y * (leftEnd + 4);

                    int rightX1 = pos.x + direction.x * (rightEnd + 1);
                    int rightY1 = pos.y + direction.y * (rightEnd + 1);
                    int rightX2 = pos.x + direction.x * (rightEnd + 2);
                    int rightY2 = pos.y + direction.y * (rightEnd + 2);
                    int rightX3 = pos.x + direction.x * (rightEnd + 3);
                    int rightY3 = pos.y + direction.y * (rightEnd + 3);
                    int rightX4 = pos.x + direction.x * (rightEnd + 4);
                    int rightY4 = pos.y + direction.y * (rightEnd + 4);


                    if (isLeagal(leftX4) && isLeagal(leftY4))
                    {
                        // 冲四 O+OOO 当前棋子的其中一侧是 空+己方+己方+己方
                        if (givenBoard[leftX1, leftY1] == Helper.emptyMark &&
                            givenBoard[leftX2, leftY2] == mark &&
                            givenBoard[leftX3, leftY3] == mark &&
                            givenBoard[leftX4, leftY4] == mark)
                        {
                            blockfour++;
                            continue;
                        }

                        // 活三 +O+OO+ 一侧是空，另一侧是 空+己方+己方+空
                        if (isLeagal(rightX1) && isLeagal(rightY1) && givenBoard[rightX1, rightY1] == Helper.emptyMark &&
                            givenBoard[leftX1, leftY1] == Helper.emptyMark &&
                            givenBoard[leftX2, leftY2] == mark &&
                            givenBoard[leftX3, leftY3] == mark &&
                            givenBoard[leftX4, leftY4] == Helper.emptyMark)
                        {
                            three++;
                            continue;
                        }

                        // 眠三 O++OO 其中一侧是 空+空+己方+己方
                        if (givenBoard[leftX1, leftY1] == Helper.emptyMark &&
                            givenBoard[leftX2, leftY2] == Helper.emptyMark &&
                            givenBoard[leftX3, leftY3] == mark &&
                            givenBoard[leftX4, leftY4] == mark)
                        {
                            blockthree++;
                            continue;
                        }

                        // 眠三 O+O+O 其中一侧是 空+己方+空+己方 即使另一侧是空也当做眠三处理
                        if (givenBoard[leftX1, leftY1] == Helper.emptyMark &&
                            givenBoard[leftX2, leftY2] == mark &&
                            givenBoard[leftX3, leftY3] == Helper.emptyMark &&
                            givenBoard[leftX4, leftY4] == mark) 
                        {
                            blockthree++;
                            continue;
                        }

                        

                        // 眠三 XO+OO+ 一侧是壁垒 另一侧是 空+己方+己方+空
                        if (isBarrier(givenBoard, new Pos(rightX1, rightY1), mark) &&
                            givenBoard[leftX1, leftY1] == Helper.emptyMark &&
                            givenBoard[leftX2, leftY2] == mark &&
                            givenBoard[leftX3, leftY3] == mark &&
                            givenBoard[leftX4, leftY4] == Helper.emptyMark)
                        {
                            blockthree++;
                            continue;
                        }

                        // 眠三 +O+OOX 一侧是空 另一侧是 空+己方+己方+对方
                        if (isLeagal(rightX1) && isLeagal(rightY1) && givenBoard[rightX1, rightY1] == Helper.emptyMark &&
                            givenBoard[leftX1, leftY1] == Helper.emptyMark &&
                            givenBoard[leftX2, leftY2] == mark &&
                            givenBoard[leftX3, leftY3] == mark && 
                            givenBoard[leftX4, leftY4] == changeMark(mark))
                        {
                            blockthree++;
                            continue;
                        }
                    }

                    // 眠三 +O+OOX 一侧是空 另一侧是 空+己方+己方+边界
                    else if (isLeagal(leftX3) && isLeagal(leftY3))
                    {
                        if (isLeagal(rightX1) && isLeagal(rightY1) && givenBoard[rightX1, rightY1] == Helper.emptyMark &&
                            givenBoard[leftX1, leftY1] == Helper.emptyMark &&
                            givenBoard[leftX2, leftY2] == mark &&
                            givenBoard[leftX3, leftY3] == mark)
                        {
                            blockthree++;
                            continue;
                        }
                    }

                    if (isLeagal(rightX4) && isLeagal(rightY4))
                    {
                        // 冲四 O+OOO 当前棋子的其中一侧是 空+己方+己方+己方
                        if (givenBoard[rightX1, rightY1] == Helper.emptyMark &&
                            givenBoard[rightX2, rightY2] == mark &&
                            givenBoard[rightX3, rightY3] == mark &&
                            givenBoard[rightX4, rightY4] == mark)
                        {
                            blockfour++;
                            continue;
                        }

                        // 活三 +O+OO+ 一侧是空，另一侧是 空+己方+己方+空
                        if (isLeagal(leftX1) && isLeagal(leftY1) && givenBoard[leftX1, leftY1] == Helper.emptyMark &&
                            givenBoard[rightX1, rightY1] == Helper.emptyMark &&
                            givenBoard[rightX2, rightY2] == mark &&
                            givenBoard[rightX3, rightY3] == mark &&
                            givenBoard[rightX4, rightY4] == Helper.emptyMark)
                        {

                            three++;
                            continue;
                        }


                        // 眠三 O++OO 其中一侧是 空+空+己方+己方
                        if (givenBoard[rightX1, rightY1] == Helper.emptyMark &&
                            givenBoard[rightX2, rightY2] == Helper.emptyMark &&
                            givenBoard[rightX3, rightY3] == mark &&
                            givenBoard[rightX4, rightY4] == mark)
                        {
                            blockthree++;
                            continue;
                        }

                        // 眠三 O+O+O 其中一侧是 空+己方+空+己方
                        if (givenBoard[rightX1, rightY1] == Helper.emptyMark &&
                            givenBoard[rightX2, rightY2] == mark &&
                            givenBoard[rightX3, rightY3] == Helper.emptyMark &&
                            givenBoard[rightX4, rightY4] == mark)
                        {
                            blockthree++;
                            continue;
                        }

                        
                        // 眠三 XO+OO+ 一侧是壁垒 另一侧是 空+己方+己方+空
                        if (isBarrier(givenBoard, new Pos(leftX1, leftY1), mark) &&
                            givenBoard[rightX1, rightY1] == Helper.emptyMark &&
                            givenBoard[rightX2, rightY2] == mark &&
                            givenBoard[rightX3, rightY3] == mark &&
                            givenBoard[rightX4, rightY4] == Helper.emptyMark)
                        {
                            if (isBarrier(givenBoard, new Pos(leftX1, leftY1), mark))
                            {
                                blockthree++;
                                continue;
                            }

                            else
                            {
                                three++;
                                continue;
                            }
                                
                        }

                        // 眠三 +O+OOX 一侧是空 另一侧是 空+己方+己方+对方
                        if (isLeagal(leftX1) && isLeagal(leftY1) && givenBoard[leftX1, leftY1] == Helper.emptyMark &&
                            givenBoard[rightX1, rightY1] == Helper.emptyMark &&
                            givenBoard[rightX2, rightY2] == mark &&
                            givenBoard[rightX3, rightY3] == mark &&
                            givenBoard[rightX4, rightY4] == changeMark(mark))
                        {
                            blockthree++;
                            continue;
                        }
                    }

                    // 眠三 +O+OOX 一侧是空 另一侧是 空+己方+己方+边界
                    else if (isLeagal(rightX3) && isLeagal(rightY3))
                    {
                        if (isLeagal(leftX1) && isLeagal(leftY1) && givenBoard[leftX1, leftY1] == Helper.emptyMark &&
                            givenBoard[rightX1, rightY1] == Helper.emptyMark &&
                            givenBoard[rightX2, rightY2] == mark &&
                            givenBoard[rightX3, rightY3] == mark)
                        {
                            blockthree++;
                            continue;
                        }
                    }

                    // 眠三 O+O+O 两侧都是 空+己方
                    if (isLeagal(leftX2) && isLeagal(leftY2) && isLeagal(rightX2) && isLeagal(rightY2) &&
                        givenBoard[leftX1, leftY1] == Helper.emptyMark &&
                        givenBoard[leftX2, leftY2] == mark )
                    {
                        blockthree++;
                        continue;
                    }

                    // 活二或眠二 O+O+
                    if (isLeagal(leftX3) && isLeagal(leftY3) && 
                        givenBoard[leftX1, leftY1] == Helper.emptyMark &&
                        givenBoard[leftX2, leftY2] == mark &&
                        givenBoard[leftX3, leftY3] == Helper.emptyMark)
                    {
                        // 眠二 XO+O+ 一侧是空 另一侧是 空+己方+空+非壁垒
                        if (isBarrier(givenBoard, new Pos(rightX1, rightY1), mark) && !isBarrier(givenBoard, new Pos(leftX4, leftY4), mark))
                        {
                            blocktwo++;
                            continue;
                        }
                            

                        // 活二 +O+O+ 一侧是空 另一侧是 空+己方+空 这五个位置两侧至少有一个不是壁垒才能构成活二
                        else if (!isBarrier(givenBoard, new Pos(rightX1, rightY1), mark) && (!isBarrier(givenBoard, new Pos(rightX2, rightY2), mark) || !isBarrier(givenBoard, new Pos(leftX4, leftY4), mark)))
                        {
                            two++;
                            continue;
                        }
                            
                    }

                    // 活二或眠二 O+O+
                    if (isLeagal(rightX3) && isLeagal(rightY3) && 
                        givenBoard[rightX1, rightY1] == Helper.emptyMark &&
                        givenBoard[rightX2, rightY2] == mark &&
                        givenBoard[rightX3, rightY3] == Helper.emptyMark)
                    {
                        // 眠二 XO+O+ 一侧是空 另一侧是 空+己方+空+非壁垒
                        if (isBarrier(givenBoard, new Pos(leftX1, leftY1), mark) && !isBarrier(givenBoard, new Pos(rightX4, rightY4), mark))
                        {
                            blocktwo++;
                            continue;
                        }
                            

                        // 活二 +O+O+ 一侧是空 另一侧是 空+己方+空 这五个位置两侧至少有一个不是壁垒才能构成活二
                        else if(!isBarrier(givenBoard, new Pos(leftX1, leftY1), mark) && (!isBarrier(givenBoard, new Pos(leftX2, leftY2), mark) || !isBarrier(givenBoard, new Pos(rightX4, rightY4), mark)))
                        {
                            two++;
                            continue;
                        }
                            
                    }

                    // 活二或眠二 O++O
                    if(isLeagal(leftX3) && isLeagal(leftY3))
                    {
                        if(givenBoard[leftX1, leftY1] == Helper.emptyMark &&
                        givenBoard[leftX2, leftY2] == Helper.emptyMark &&
                        givenBoard[leftX3, leftY3] == mark)
                        {
                            if (isBarrier(givenBoard, new Pos(rightX1, rightY1), mark))
                            {
                                blocktwo++;
                                continue;
                            }

                            else
                            {
                                two++;
                                continue;
                            }
                                
                        }
                    }

                    // 活二或眠二 O++O
                    if(isLeagal(rightX3) && isLeagal(rightY3) &&
                        givenBoard[rightX1, rightY1] == Helper.emptyMark &&
                        givenBoard[rightX2, rightY2] == Helper.emptyMark &&
                        givenBoard[rightX3, rightY3] == mark)
                    {
                        if (isBarrier(givenBoard, new Pos(leftX1, leftY1), mark))
                        {
                            blocktwo++;
                            continue;
                        }

                        else
                        {
                            two++;
                            continue;
                        }
                            
                    }

                    // 活一
                    if(leftEmpty + rightEmpty > 4 && leftEmpty > 0 && rightEmpty > 0)
                    {
                        one++;
                        continue;
                    }

                    // 眠一
                    if(leftEmpty == 0 && rightEmpty >= 4 || rightEmpty == 0 && leftEmpty >= 4)
                    {
                        blockone++;
                        continue;
                    }
                    


                }
            }

            // 活四 双冲四 冲四活三
            if (four > 0 || blockfour > 1 || (blockfour == 1 && three > 0))
            {
                returnValue = Helper.LEVEL2;
            }

            // 双活三
            else if (three > 1)
            {
                returnValue = Helper.LEVEL3;
            }

            // 活三眠三
            else if (three > 0 && blockthree > 0)
            {
                returnValue = Helper.LEVEL4;
            }

            // 冲四
            else if(blockfour > 0)
            {
                returnValue = Helper.LEVEL5;
            }

            // 活三
            else if(three > 0)
            {
                returnValue = Helper.LEVEL6;
            }

            // 双活二
            else if(two > 1)
            {
                returnValue = Helper.LEVEL7;
            }

            // 眠三
            else if (blockthree > 0)
            {
                returnValue = Helper.LEVEL8;
            }

            // 活二
            else if(two > 0)
            {
                returnValue = Helper.LEVEL9;
            }

            // 眠二
            else if(blocktwo > 0)
            {
                returnValue = Helper.LEVEL10;
            }



            if (mark == Helper.playerMark)
                return -returnValue;
            if (mark == Helper.AIMark)
                return returnValue;

            return 0;
        }

        /// <summary>
        /// 判断是否越界
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool isLeagal(int x)
        {
            return x >= 0 && x < 15;
        }

        /// <summary>
        /// 判断是否碰到壁垒(边界或对方棋子)
        /// </summary>
        /// <param name="board1"></param>
        /// <param name="p"></param>
        /// <param name="mark"></param>
        /// <returns></returns>
        public bool isBarrier(char[,] board1, Pos p, char mark)
        {
            if(p.x < 0 || p.x > 14 || p.y < 0 || p.y > 14)
            {
                return true;
            }
            if(board1[p.x, p.y] == changeMark(mark))
            {
                return true;
            }
            return false;
        }

        

        /// <summary>
        /// 交换落子轮
        /// </summary>
        /// <param name="turn"></param>
        /// <returns></returns>
        private int changeTurn(int turn)
        {
            return turn == 1 ? 0 : 1;
        }

        private char changeMark(int mark)
        {
            if (mark == Helper.AIMark)
                return Helper.playerMark;
            else
                return Helper.AIMark;

        }


        /// <summary>
        /// 根据落子点p 以及落子方c 生成新的盘面
        /// </summary>
        /// <param name="p"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public char[,] newBoard(Pos p, char c)
        {
            //char[,] newboard = new char[3,3];
            //for (int i = 0; i < 3; i++)
            //    for (int j = 0; j < 3; j++)
            //        newboard[i, j] = board[i, j];

            char[,] newboard = (char[,])board.Clone();
            newboard[p.x, p.y] = c;
            return newboard;
        }

        // 可行的落子点，已落子点周围一圈（或者N圈，通过hasNeighbor 方法的第三个参数进行设置）都认为是可行点；
        public List<Pos> getAvailableMoves()
        {
            List<Pos> result = new List<Pos>();

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (board[i, j] == '_')
                    {

                        if (hasNeighbor(i, j, 1))
                        {
                            result.Add(new Pos(i, j));
                        }

                    }

                }
            }

            return result;
        }



        public List<Pos> topKMoves(List<Pos> rawAvailableMoves, int sizeAfter)
        {
            List<Pos> result = new List<Pos>();
            return result;
        }

        public List<Pos> MinKMoves(List<Pos> rawAvailableMoves, int sizeAfter)
        {
            List<Pos> result = new List<Pos>();
            return result;
        }

        /// <summary>
        /// 缩小可行落子点的范围，选取落子后估值最大的若干个点进行扩展
        /// </summary>
        /// <param name="rawAvailableMoves"></param>
        /// <param name="sizeAfter"></param>
        /// <returns></returns>
        public List<Pos> shrinkAvailableMoves(List<Pos> rawAvailableMoves, int sizeAfter, char mark)
        {
            //if (mark == Helper.AIMark)
            //    return topK(rawAvailableMoves, sizeAfter);
            //else
            //    return MinK(rawAvailableMoves, sizeAfter);
            return topK(rawAvailableMoves, sizeAfter);
        }


        /// <summary>
        /// 返回估值最高的K个落子点 最小堆
        /// </summary>
        /// <param name="list"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<Pos> topK(List<Pos> list, int K)
        {
            List<Pos> result = new List<Pos>();

            if( K >= list.Count)
            {
                return list;
            }

            for(int i = 0; i < K; i++)
            {
                result.Add(list[i]);
            }

            buildMinHeap(result);

            for(int j = K; j < list.Count; j++)
            {
                var pos = list[j];
                var minPos = result[0];
                int value = evaluate(board, pos);
                int min = evaluate(board, minPos);

                if(value > min)
                {
                    result[0] = pos;
                    heapifyMin(result, 0, K);
                }
            }

            return result;
        }

        /// <summary>
        /// 返回估值最小的K个落子点 最大堆
        /// </summary>
        /// <param name="list"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public List<Pos> MinK(List<Pos> list, int K)
        {
            List<Pos> result = new List<Pos>();

            if (K >= list.Count)
            {
                return list;
            }

            for (int i = 0; i < K; i++)
            {
                result.Add(list[i]);
            }

            buildMaxHeap(result);

            for (int j = K; j < list.Count; j++)
            {
                var pos = list[j];
                var minPos = result[0];
                int value = evaluate(board, pos);
                int min = evaluate(board, minPos);

                if (value < min)
                {
                    result[0] = pos;
                    heapifyMax(result, 0, K);
                }
            }

            return result;
        }

        /// <summary>
        /// 建立最小堆
        /// </summary>
        /// <param name="list"></param>
        public void buildMinHeap(List<Pos> list)
        {
            for (int i = list.Count / 2 - 1; i >= 0; i--)
            {
                heapifyMin(list, i, list.Count);
            }
        }

        /// <summary>
        /// 建立最大堆
        /// </summary>
        /// <param name="list"></param>
        public void buildMaxHeap(List<Pos> list)
        {
            for (int i = list.Count / 2 - 1; i >= 0; i--)
            {
                heapifyMax(list, i, list.Count);
            }
        }

        /// <summary>
        /// 调整最小堆
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        public void heapifyMin(List<Pos> list, int index, int size)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int min = index;


            //int leftValue = evaluate(board, list[left], turn);
            //int rightValue = evaluate(board, list[right], turn);
            //int minValue = evaluate(board, list[min], turn);

            if (left < size && evaluate(board, list[left]) < evaluate(board, list[min]))
            {
                min = left;

            }

            if (right < size && evaluate(board, list[right]) < evaluate(board, list[min]))
            {
                min = right;
            }

            if (min != index)
            {
                var temp = list[index];
                list[index] = list[min];
                list[min] = temp;
                heapifyMin(list, min, size);
            }
        }

        /// <summary>
        /// 调整最大堆
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        public void heapifyMax(List<Pos> list, int index, int size)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int max = index;


            //int leftValue = evaluate(board, list[left], turn);
            //int rightValue = evaluate(board, list[right], turn);
            //int minValue = evaluate(board, list[min], turn);

            if (left < size && evaluate(board, list[left]) > evaluate(board, list[max]))
            {
                max = left;

            }

            if (right < size && evaluate(board, list[right]) > evaluate(board, list[max]))
            {
                max = right;
            }

            if (max != index)
            {
                var temp = list[index];
                list[index] = list[max];
                list[max] = temp;
                heapifyMax(list, max, size);
            }
        }



        public bool hasNeighbor(int i, int j, int neighborRange)
        {
            int leftbound = (j - neighborRange) > 0 ? (j - neighborRange) : 0;
            int rightbound = (j + neighborRange) < 15 ? (j + neighborRange) : 0;
            int topbound = (i - neighborRange) > 0 ? (i - neighborRange) : 0;
            int bottombound = (i + neighborRange) < 15 ? (i + neighborRange) : 0;

            for (int m = topbound; m <= bottombound; m++)
            {
                for (int n = leftbound; n <= rightbound; n++)
                {
                    if (m == i && n == j)
                        continue;
                    if (board[m, n] != '_')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 落子并绘制新盘面
        /// </summary>
        public void move()
        {
            board = nextMove.board;
            drawBoard();
        }

        //  TODO
        public bool checkFinishedAccordingToLastMove(Pos pos)
        {

            return false;
        }


        // return the winning path
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
                            //Console.WriteLine("{0} is winner.", givenBoard[i, j]);
                            for (int jj = j; jj < j + 5; jj++)
                            {
                                winningPath.Add(new Pos(i, jj));
                                //Console.WriteLine("({0}, {1}) ", i, jj);
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
                            //Console.WriteLine("{0} is winner.", givenBoard[i, j]);
                            for (int ii = i; ii < i + 5; ii++)
                            {
                                winningPath.Add(new Pos(ii, j));
                                //Console.WriteLine("({0}, {1}) ", ii, j);
                            }
                            return winningPath;
                        }
                    }
                }
            }

            // check diagonal \
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (givenBoard[i, j] == '_')
                        continue;
                    for (int k = 1; k < 5; k++)
                    {
                        if (givenBoard[i, j] != givenBoard[i + k, j + k])
                        {
                            break;
                        }
                        if (k == 4)
                        {
                            //Console.WriteLine("{0} is winner.", givenBoard[i, j]);
                            for (int offset = 0; offset < 5; offset++)
                            {
                                winningPath.Add(new Pos(i + offset, j + offset));
                                //Console.WriteLine("({0}, {1}) ", i + offset, j + offset);
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
                            //Console.WriteLine("{0} is winner.", givenBoard[i, j]);
                            for (int offset = 0; offset < 5; offset++)
                            {
                                winningPath.Add(new Pos(i + offset, j - offset));
                                //Console.WriteLine("({0}, {1}) ", i + offset, j - offset);
                            }
                            return winningPath;
                        }
                    }
                }
            }

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (board[i, j] == '_')
                    {
                        //Console.WriteLine("Not finished.");
                        return winningPath;    //  empty list, not finished;
                    }
                }
            }

            winningPath.Add(new Pos(99, 99));  //  Tie
            return winningPath;
        }
    }


}
