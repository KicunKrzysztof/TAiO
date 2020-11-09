using System;
using System.Collections.Generic;
using Algorithm;
using Algorithm.Model;
using Microsoft.Diagnostics.Tracing.Parsers.AspNet;
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
        [TestMethod]
        public void AreEqaul()
        {

            var solA = new int[,]
            {
                {1, 2, 2, 2},
                {1, 3, 3, 4},
                {1, 3, 3, 4},
                {1, 0, 0, 4}
            };
            var solB = new int[,]
            {
                {2, 1, 1, 1},
                {2, 4, 4, 3},
                {2, 4, 4, 3},
                {2, 0, 0, 3}
            };

            var solutionComparer = new SolutionComparer();
            
            Assert.IsTrue(solutionComparer.AreEqual(solA, solB));
        }
        [TestMethod]
        public void AreNotEqaul()
        {

            var solA = new int[,]
            {
                {1, 2, 2, 0},
                {1, 0, 2, 0},
                {1, 0, 0, 0},
                {1, 0, 0, 0}
            };
            var solB = new int[,]
            {
                {2, 1, 1, 1},
                {2, 0, 0, 0},
                {2, 0, 0, 0},
                {2, 0, 0, 0}
            };

            var solutionComparer = new SolutionComparer();

            Assert.IsFalse(solutionComparer.AreEqual(solA, solB));
        }

        [TestMethod]
        public void ArePiecesEqual()
        {

                var piece = new Piece(new List<Point>
            {
                new Point(0, 0),
                new Point(1, 0),
                new Point(2, 0),
                new Point(3, 0),
            });

                var other = piece.RotateRight().RotateRight();

            

            Assert.IsTrue(piece.Compare(other));
        }

        [TestMethod]
        public void PiecesTOUnique()
        {

            var piece = new Piece(new List<Point>
            {
                new Point(0, 0),
                new Point(1, 0),
                new Point(2, 0),
                new Point(3, 0),
            });

            var other = piece.RotateRight().RotateRight();

            var pieces = new List<Piece>{piece, other};
            var uniqueFinder = new UniquePiecesFinder();

            Assert.IsTrue(uniqueFinder.FindUniquePieces(pieces).Count == 1);
        }
    }
}
