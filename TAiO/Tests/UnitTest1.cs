using System;
using System.Collections.Generic;
using Algorithm;
using Algorithm.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //[1, 1][1, 2][0, 1][0, 0]
            var piece = new Piece(new List<Point>
            {
                new Point(1, 1),
                new Point(1, 2),
                new Point(0, 1),
                new Point(0, 0),
            });

            var resul = piece.GetBoardLocation(new Point(3, 0));

        }
        [TestMethod]
        public void TestMethod2()
        {

            var piece = new Piece(new List<Point>
            {
                new Point(0, 1),
                new Point(1, 1),
                new Point(2, 1),
                new Point(3, 1),
            });

            var resul = piece.RotateRight();
            var resul1 = piece.RotateRight();
            var resul2 = piece.RotateRight();

        }
    }
}
