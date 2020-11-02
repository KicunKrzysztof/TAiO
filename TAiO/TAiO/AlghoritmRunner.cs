using System.Collections.Generic;
using System.Runtime.InteropServices;
using Algorithm;
using Algorithm.Heuristic;
using Algorithm.Model;

namespace TAiO
{
    public class AlghoritmRunner
    {
        PiecesGenerator piecesGenerator = new PiecesGenerator();
        public List<int[,]> Run(AlgorithmType algorithmType, int pieceSize, int pieceCount)
        {
            var pieces = piecesGenerator.GeneratePieces(pieceCount, pieceSize);
            //var pieces = new List<Piece>
            //{
            //    new Piece(new List<Point>()
            //    {
            //        new Point(1,1),
            //        new Point(0,1),
            //        new Point(0,2),
            //        new Point(0,3)
            //    }),
            //    new Piece(new List<Point>()
            //    {
            //        new Point(1,1),
            //        new Point(1,2),
            //        new Point(2,1),
            //        new Point(2,2)
            //    }),
            //    new Piece(new List<Point>()
            //    {
            //        new Point(0,1),
            //        new Point(0,2),
            //        new Point(0,3),
            //        new Point(1,2)
            //    }),
            //    new Piece(new List<Point>()
            //    {
            //        new Point(0,0),
            //        new Point(1,0),
            //        new Point(2,0),
            //        new Point(3,0)
            //    }),
            //};
            var smallestSquareFinder = AlghoritmMapper.Map(algorithmType);
            smallestSquareFinder.Pieces = pieces;
            var solutions = smallestSquareFinder.CalculateSolutions();
            return solutions;

        }
    }

    public class AlghoritmMapper
    {
        public static SmallestSquareFinder Map(AlgorithmType algorithmType)
        {
            switch (algorithmType)
            {
                case AlgorithmType.Heuristic:
                    return new SmallestSquareHeuristic();
                case AlgorithmType.Optimal:
                    return new SmallestSquareOptimalFinder();
                default:
                    return null;
            }
        }
    }

    public enum AlgorithmType
    {
        Optimal, Heuristic
    }
}
