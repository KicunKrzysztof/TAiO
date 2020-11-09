using System.Collections.Generic;
using System.Runtime.InteropServices;
using Algorithm;
using Algorithm.Model;

namespace TAiO
{
    public class AlghoritmRunner
    {
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
            PiecesGenerator piecesGenerator = new PiecesGenerator();
            var pieces = piecesGenerator.GeneratePieces(pieceCount, pieceSize);
            var smallestSquareFinder = AlghoritmFactory.Create(algorithmType, pieces);
            return smallestSquareFinder.CalculateSolutions();
        }
    }
}
