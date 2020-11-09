using System.Collections.Generic;
using Algorithm.Heuristic;
using Algorithm.Model;
using Algorithm.OptimalSolution;

namespace TAiO
{
    public class AlghoritmFactory
    {
        public static SmallestSquareFinder Create(AlgorithmType algorithmType, List<Piece> pieces)
        {
            switch (algorithmType)
            {
                case AlgorithmType.Heuristic:
                    return new SmallestSquareHeuristic(pieces);
                case AlgorithmType.Optimal:
                    return new SmallestSquareOptimalSpecifiedPieces(pieces);
                default:
                    return null;
            }
        }
        public static SmallestSquareFinder CreateOptimalSpecified(Dictionary<Piece, int> specifiedPieces)
        {
            return new SmallestSquareOptimalSpecifiedPieces(specifiedPieces);
        }
    }
}