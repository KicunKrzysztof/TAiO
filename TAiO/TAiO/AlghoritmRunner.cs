using System.Collections.Generic;
using System.Runtime.InteropServices;
using Algorithm;
using Algorithm.Heuristic;
using Algorithm.Model;
using Algorithm.OptimalSolution;

namespace TAiO
{
    public class AlghoritmRunner
    {
        PiecesGenerator piecesGenerator = new PiecesGenerator();

        public List<Solution> Run(AlgorithmType algorithmType, int pieceSize, List<int> n_list)
        {
            PredefinedPieces generator = GeneratorMapper.Map(pieceSize);
            if (generator == null)
                return null;
            var pieces = generator.GeneratePieces(n_list);
            if (pieces == null)
                return null;
            var smallestSquareFinder = AlghoritmFactory.Create(algorithmType, pieces);
            return smallestSquareFinder.CalculateSolutions();
        }
        public List<Solution> RunPredefined(int pieceSize, List<int> n_list)
        {
            PredefinedPieces generator = GeneratorMapper.Map(pieceSize);
            if (generator == null)
                return null;
            var pieces = generator.GeneratePredefinedPieces(n_list);
            if (pieces == null)
                return null;
            var smallestSquareFinder = AlghoritmFactory.CreateOptimalSpecified(pieces);
            return smallestSquareFinder.CalculateSolutions();
        }
        public List<Solution> Run(AlgorithmType algorithmType, int pieceSize, int pieceCount)
        {
            var pieces = piecesGenerator.GeneratePieces(pieceCount, pieceSize);
            var smallestSquareFinder = AlghoritmFactory.Create(algorithmType, pieces);
            return smallestSquareFinder.CalculateSolutions();
        }
    }

    public class AlghoritmFactory
    {
        public static SmallestSquareFinder Create(AlgorithmType algorithmType, List<Piece> pieces)
        {
            switch (algorithmType)
            {
                case AlgorithmType.Heuristic:
                    return new SmallestSquareHeuristic(pieces);
                case AlgorithmType.Optimal:
                    return new SmallestSquareOptimalFinder(pieces);
                default:
                    return null;
            }
        }
        public static SmallestSquareFinder CreateOptimalSpecified(Dictionary<Piece, int> specifiedPieces)
        {
            return new SmallestSquareOptimalSpecifiedPieces(specifiedPieces);
        }
    }

    public class GeneratorMapper
    {
        public static PredefinedPieces Map(int pieceSize)
        {
            switch (pieceSize)
            {
                case 5:
                    return new Pentomino();
                case 6:
                    return new Hexomino();
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
