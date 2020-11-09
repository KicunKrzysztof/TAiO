using System.Collections.Generic;
using Algorithm;
using Algorithm.Heuristic;
using Algorithm.Model;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using TAiO;

namespace Benchmark
{
    public class Main2
    {
        public static void Main()
        {
            var config = new ManualConfig()
                .WithOptions(ConfigOptions.DisableOptimizationsValidator)
                .AddValidator(JitOptimizationsValidator.DontFailOnError)
                .AddLogger(ConsoleLogger.Default)
                .AddExporter(new CsvExporter(CsvSeparator.CurrentCulture))
                .AddExporter(new HtmlExporter())
                .AddColumnProvider(DefaultColumnProviders.Instance);

            BenchmarkRunner.Run<Benchmark>(config);
        }
    }
    [CsvExporter]
    [SimpleJob(RuntimeMoniker.Net48, baseline: true, warmupCount: 0, invocationCount: 1, targetCount: 10)]
    public class Benchmark
    {
        private PiecesGenerator piecesGenerator = new PiecesGenerator();
        private SmallestSquareOptimalFinder smallestSquareOptimal = new SmallestSquareOptimalFinder();
        private SmallestSquareHeuristic smallestSquareHeuristic = new SmallestSquareHeuristic();

        [Params(5, 6)]
        public int PieceSize;

        [Params(1, 2,3,4,5,6,7)]
        public int PieceCountOptimal;

        

        private List<Piece> pieces;

        [IterationSetup]
        public void CreatePieces()
        {
            pieces = piecesGenerator.GeneratePieces(PieceCountOptimal, PieceSize);
        }

        [Benchmark]
        public void Optimal()
        {
            smallestSquareOptimal.pieces = pieces;
            smallestSquareOptimal.CalculateSolutions();
        }
    }
    [CsvExporter]
    [SimpleJob(RuntimeMoniker.Net48, baseline: true, warmupCount:0, invocationCount:1, targetCount:1)]
    public class HeuristicBenchmark
    {
        private PiecesGenerator piecesGenerator = new PiecesGenerator();
        private SmallestSquareHeuristic smallestSquareHeuristic = new SmallestSquareHeuristic();

        [Params(5, 6)]
        public int PieceSize;


        [Params(1, 2, 3, 4, 5, 6, 7, 20, 50, 75, 100, 150,
                200,
                230,
                260,
                290,
                300,
                400,
                500,
                600,
                700,
                800,
                900,
                1000

            )

        ]
        public int PieceCount;


        private List<Piece> pieces;

        [IterationSetup]
        public void CreatePieces()
        {
            pieces = piecesGenerator.GeneratePieces(PieceCount, PieceSize);
        }

        [Benchmark]
        public void Heuristic()
        {
            smallestSquareHeuristic.pieces = pieces;
            smallestSquareHeuristic.CalculateSolutions();
        }
    }
}