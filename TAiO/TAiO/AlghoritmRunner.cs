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
