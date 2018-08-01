﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HakuGoCmd;

namespace UnitTestHakuGo
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// test 成五
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            BoardState bs = new BoardState();

            char[,] testBoard = new char[15, 15] {
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 1
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 2
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 3
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 4
                { '_', '_', '_', '_', '_', 'x', 'x', 'x', 'x', '_', '_', '_', '_', '_', '_', },// 5
                { '_', '_', '_', '_', '_', '_', 'o', '_', '_', '_', '_', '_', '_', '_', '_', },// 6
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

            Pos ppp = new Pos(4, 4);
            int vvvalue = bs.evaluateOneSide(testBoard, ppp, Helper.AIMark);
            Assert.AreEqual(vvvalue, Helper.LEVEL1);

            ppp = new Pos(4,9);
            vvvalue = bs.evaluateOneSide(testBoard, ppp, Helper.AIMark);
            Assert.AreEqual(vvvalue, Helper.LEVEL1);
        }


        /// <summary>
        /// test 活四
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            BoardState bs = new BoardState();

            char[,] testBoard = new char[15, 15] {
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 1
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 2
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 3
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 4
                { '_', '_', '_', '_', '_', 'x', 'x', 'x', '_', '_', '_', '_', '_', '_', '_', },// 5
                { '_', '_', '_', '_', '_', '_', 'o', '_', '_', '_', '_', '_', '_', '_', '_', },// 6
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

            Pos ppp = new Pos(4, 4);
            int vvvalue = bs.evaluateOneSide(testBoard, ppp, Helper.AIMark);
            Assert.AreEqual(vvvalue, Helper.LEVEL2);

            ppp = new Pos(4, 8);
            vvvalue = bs.evaluateOneSide(testBoard, ppp, Helper.AIMark);
            Assert.AreEqual(vvvalue, Helper.LEVEL2);
        }

        /// <summary>
        /// test 双冲四
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            BoardState bs = new BoardState();

            char[,] testBoard = new char[15, 15] {
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 1
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 2
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 3
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 4
                { '_', '_', '_', '_', '_', 'x', 'x', 'x', '0', '_', '_', '_', '_', '_', '_', },// 5
                { '_', '_', '_', '_', '_', 'x', 'o', '_', '_', '_', '_', '_', '_', '_', '_', },// 6
                { '_', '_', '_', '_', '_', '_', 'x', '_', '_', '_', '_', '_', '_', '_', '_', },// 7
                { '_', '_', '_', '_', '_', '_', '_', 'x', '_', '_', '_', '_', '_', '_', '_', },// 8
                { '_', '_', '_', '_', '_', '_', '_', '_', 'o', '_', '_', '_', '_', '_', '_', },// 9
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 10
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 11
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 12
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 13
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 14
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 15
            };

            bs.board = testBoard;

            Pos ppp = new Pos(4, 4);
            int vvvalue = bs.evaluateOneSide(testBoard, ppp, Helper.AIMark);
            Assert.AreEqual(vvvalue, Helper.LEVEL2);

            
        }

        /// <summary>
        /// test 冲四活三
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            BoardState bs = new BoardState();

            char[,] testBoard = new char[15, 15] {
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 1
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 2
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 3
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 4
                { '_', '_', '_', '_', '_', 'x', 'x', 'x', '0', '_', '_', '_', '_', '_', '_', },// 5
                { '_', '_', '_', '_', '_', 'x', 'o', '_', '_', '_', '_', '_', '_', '_', '_', },// 6
                { '_', '_', '_', '_', '_', '_', 'x', '_', '_', '_', '_', '_', '_', '_', '_', },// 7
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 8
                { '_', '_', '_', '_', '_', '_', '_', '_', 'o', '_', '_', '_', '_', '_', '_', },// 9
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 10
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 11
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 12
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 13
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 14
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 15
            };

            bs.board = testBoard;

            Pos ppp = new Pos(4, 4);
            int vvvalue = bs.evaluateOneSide(testBoard, ppp, Helper.AIMark);
            Assert.AreEqual(vvvalue, Helper.LEVEL2);

            
        }

        /// <summary>
        /// test 双活三
        /// </summary>
        [TestMethod]
        public void TestMethod5()
        {
            BoardState bs = new BoardState();

            char[,] testBoard = new char[15, 15] {
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 1
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 2
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 3
                { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 4
                { '_', '_', '_', '_', '_', 'x', 'x', '_', '_', '_', '_', '_', '_', '_', '_', },// 5
                { '_', '_', '_', '_', '_', 'x', '_', '_', '_', '_', '_', '_', '_', '_', '_', },// 6
                { '_', '_', '_', '_', '_', '_', 'x', '_', '_', '_', '_', '_', '_', '_', '_', },// 7
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

            Pos ppp = new Pos(4, 4);
            int vvvalue = bs.evaluateOneSide(testBoard, ppp, Helper.AIMark);
            Assert.AreEqual(vvvalue, Helper.LEVEL3);
        }
    }
}
