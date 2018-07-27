﻿using System;
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

            // <winningPath> store the five positions if one has won;
            // empty is the game is not finished yet;
            // store Pos(99,99) is game is over and there is a tie;

            //List<Pos> winningPath = new List<Pos>();
            //winningPath = bs.checkFinished(testBoard);

            bs.board = testBoard;
            //if (bs.hasNeighbor(7, 0, 2))
            //{
            //    Console.WriteLine("has neighbor.");
            //}
            //bs.drawBoard();


            bs.drawBoard();
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
                    bs.updateBoard(bs.getInputPos(), 'o');
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
                    return Helper.FIVE - depth;
                }

                if (board[result[0].x, result[0].y] == 'o')
                {
                    //Console.WriteLine("winner is o.");
                    return -Helper.FIVE + depth;
                }
            }

            if (result.Count == 1)
            {
                //Console.WriteLine("Tie.");
                return 0;
            }

            List<Pos> availableMoves = getAvailableMoves();
            availableMoves = shrinkAvailableMoves(availableMoves, Helper.MOVESIZE);

            //if (depth >= Helper.searchDepth || checkFinished(board).Any())
            //{
            //    int value = evaluate(board);
            //    return value;
            //}

            // Max, computer's turn 
            if (turn == 0)
            {

                int maxInChild = int.MinValue;
                foreach (var move in availableMoves)
                {
                    int childScore;
                    BoardState childState = new BoardState(newBoard(move, 'x'), changeTurn(turn), depth + 1, alpha, beta);
                    if (depth >= Helper.searchDepth || checkFinished(childState.board).Count == 5)
                    {
                        childScore = evaluate(childState.board);
                        nextMove = childState;
                        return childScore;
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
                        return alpha;
                }
                return maxInChild;
            }

            //Min, player's turn
            else if (turn == 1)
            {

                int minInChild = int.MaxValue;
                foreach (var move in availableMoves)
                {
                    BoardState childState = new BoardState(newBoard(move, 'o'), changeTurn(turn), depth + 1, alpha, beta);
                    int childScore;
                    if (depth >= Helper.searchDepth || checkFinished(childState.board).Count == 5)
                    {
                        childScore = evaluate(childState.board);
                        nextMove = childState;
                        return childScore;
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
                        return beta;
                }

                return minInChild;
            }

            return 0;

        }


        // 盘面评估函数
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
                                    return Helper.FIVE;
                                if (givenBoard[i, j] == Helper.playerMark)
                                    return -Helper.FIVE;
                            }
                        }
                    }
                }
            }

            // 活四
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
                                        return Helper.FOUR;
                                    if (givenBoard[i + direction.x, j + direction.y] == Helper.playerMark)
                                        return -Helper.FOUR;
                                }
                            }

                        }
                    }

                }
            }


            // 活三
            //for (int i = 0; i < 15; i++)
            //{
            //    for (int j = 0; j < 15; j++)
            //    {
            //        foreach (var direction in directions)
            //        {
            //            // 如果延伸段超过边界 则不可能再有活四 
            //            int x = i + direction.x * 5;
            //            int y = j + direction.y * 5;
            //            if (x < 0 || x > 14 || y < 0 || y > 14)
            //            {
            //                break;
            //            }
            //            if (givenBoard[i, j] == '_' && givenBoard[i + direction.x * 5, j + direction.y * 5] == '_')
            //            {
            //                for (int range = 1; range <= 4; range++)
            //                {
            //                    if (givenBoard[i, j] == givenBoard[i + direction.x * range, j + direction.y * range])
            //                        return 50000;
            //                }


            //            }
            //        }

            //    }
            //}

            return 0;
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


        // 缩小可行落子点的范围，选取落子后估值最大的若干个点进行扩展
        public List<Pos> shrinkAvailableMoves(List<Pos> rawAvailableMoves, int sizeAfter)
        {
            return topK(rawAvailableMoves, sizeAfter);
        }


        /// <summary>
        /// 返回估值最高的K个落子点
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
                int value = evaluate(newBoard(pos, Helper.AIMark));
                int min = evaluate(newBoard(minPos, Helper.AIMark));

                if(value > min)
                {
                    result[0] = pos;
                    heapifyMin(result, 0, K);
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
            for (int i = list.Count / 2 - 1; i > 0; i--)
            {
                heapifyMin(list, i, list.Count);
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

            var leftBoard = newBoard(list[left], Helper.AIMark);
            var rightBoard = newBoard(list[right], Helper.AIMark);
            var minBoard = newBoard(list[min], Helper.AIMark);

            int leftValue = evaluate(leftBoard);
            int rightValue = evaluate(rightBoard);
            int maxValue = evaluate(minBoard);

            if (left < size && leftValue > maxValue)
            {
                min = left;
            }

            if (right < size && rightValue > maxValue)
            {
                min = right;
            }

            if (min != index)
            {
                var temp = list[index];
                list[min] = temp;
                list[index] = list[min];
                heapifyMin(list, min, size);
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
