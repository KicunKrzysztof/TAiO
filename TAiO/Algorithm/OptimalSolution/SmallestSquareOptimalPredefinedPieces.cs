using Algorithm.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TAiO;

namespace Algorithm.OptimalSolution
{
    /// <summary>
    /// Algorytm optymalny, listę klocków zamienia na słownik unikalnych klocków (nie uwzgledniajac obrotow) i ich wystąpień
    /// </summary>
    public class SmallestSquareOptimalPredefinedPieces : SmallestSquareFinder
    {
        private readonly SymmetricPieceChecker symmetricPieceChecker = new SymmetricPieceChecker();
        private readonly PieceLocationFinder pieceLocationFinder = new PieceLocationFinder();

        private Stack<SolutionRow> solutionRows;
        private List<Solution> solutions;

        /// <summary>
        /// Slownik unikalnych klockow i ich wystapien
        /// </summary>
        private Dictionary<Piece, int> uniquePieces;
        /// <summary>
        /// Mapowanie indeksu unikatowego klocka na obiekt klocka
        /// </summary>
        private Dictionary<int, Piece> indexMapping;
        /// <summary>
        /// Mapowanie indeksu unikatowego klocka na liczbe wystapien
        /// </summary>
        private Dictionary<int, int> countMapping;
        /// <summary>
        /// Mapowanie indeksu unikatowego klocka i jego wystapienia na kolor 
        /// </summary>
        private Dictionary<(int, int), int> colorMapping;
        private int PieceCount => uniquePieces.Sum((a) => a.Value);


        /// <summary>
        /// Konstruktor zamieniajacy liste dowolnych klockow na slownik unikalnych klockow
        /// </summary>
        /// <param name="pieces"></param>
        public SmallestSquareOptimalPredefinedPieces(List<Piece> pieces)
        {
            var uniquePiecesFinder = new UniquePiecesFinder();
            uniquePieces = uniquePiecesFinder.FindUniquePieces(pieces);
            InitializeMappings();
        }

        public SmallestSquareOptimalPredefinedPieces(Dictionary<Piece, int> uniquePieces)
        {
            this.uniquePieces = uniquePieces;
            InitializeMappings();
        }

        public override List<Solution> CalculateSolutions()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (uniquePieces == null || uniquePieces.Count == 0)
            {
                return new List<Solution>();
            }

            solutions = new List<Solution>();
            solutionRows = new Stack<SolutionRow>();

            //1.1
            var boardSize = CalculateInitialBoardSize();
            do
            {
                Board = new Board(boardSize);
                F(0, 0);
                boardSize++;
            } while (!solutions.Any());
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            return solutions;
        }

        #region Private methods
        /// <summary>
        /// Rekurencyjne stawianie klockow na podstawie indeksu unikalnego klocka i numeru jego wystapienia
        /// </summary>
        /// <param name="pieceTypeIndex"></param>
        /// <param name="currentTypeCount"></param>
        private void F(int pieceTypeIndex, int currentTypeCount)
        {
            if (pieceTypeIndex >= uniquePieces.Keys.Count)
            {
                AddCurrentSolution();
                return;
            }

            var currentPiece = indexMapping[pieceTypeIndex];
            //F.1
            //F.2 - F.4

            if (countMapping[pieceTypeIndex] == 0)
            {
                F(pieceTypeIndex + 1, 0);
            }
            else
            {
                var pieceRotations = new Piece[4];
                for (int rotationIndex = 0; rotationIndex < 4; rotationIndex++)
                {
                    pieceRotations[rotationIndex] = currentPiece;
                    var alreadyCheckedSymmetricRotation =
                        symmetricPieceChecker.CheckIfAlreadyCheckedSymmetricRotation(rotationIndex, currentPiece,
                            pieceRotations);

                    if (!alreadyCheckedSymmetricRotation)
                    {
                        var availableLocations = pieceLocationFinder.GetAvailableLocations(Board, currentPiece);
                        foreach (var availableLocation in availableLocations)
                        {
                            var pieceValue = colorMapping[(pieceTypeIndex, currentTypeCount)];
                            solutionRows.Push(new SolutionRow(pieceTypeIndex,
                                new Point(availableLocation.X, availableLocation.Y), rotationIndex, pieceValue));
                            SetPieceOnBoard(availableLocation, currentPiece, pieceValue);
                            if (currentTypeCount == countMapping[pieceTypeIndex] - 1)
                            {
                                F(pieceTypeIndex + 1, 0);
                            }
                            else
                            {
                                F(pieceTypeIndex, currentTypeCount + 1);

                            }
                            SetPieceOnBoard(availableLocation, currentPiece, 0);
                            solutionRows.Pop();
                        }
                    }
                    currentPiece = currentPiece.RotateRight();
                }
            }


        }
        private int CalculateInitialBoardSize()
        {
            var piecesArea = PieceCount * uniquePieces.FirstOrDefault().Key.Size;
            return (int)Math.Ceiling(Math.Sqrt(piecesArea));
        }
        private void InitializeMappings()
        {
            int index = 0;
            indexMapping = uniquePieces.Keys.ToList().ToDictionary(a => index++);
            index = 0;
            countMapping = uniquePieces.Values.ToList().ToDictionary(a => index++);

            int colorIndex = 1;
            colorMapping = new Dictionary<(int, int), int>();
            for (int typeIndex = 0; typeIndex < this.uniquePieces.Count; typeIndex++)
            {
                for (int i = 0; i < countMapping[typeIndex]; i++)
                {
                    colorMapping.Add((typeIndex, i), colorIndex);
                    colorIndex++;
                }
            }
        }
        private void AddCurrentSolution()
        {
            var cur = new SolutionRow[solutionRows.Count];
            solutionRows.CopyTo(cur, 0);
            solutions.Add(new Solution(Board.Size, cur, uniquePieces.Keys.ToList()));
        }
        private void SetPieceOnBoard(Point location, Piece piece, int pieceValue)
        {
            var pieceBoardLocation = piece.GetBoardLocation(location);
            foreach (var boardLocation in pieceBoardLocation)
            {
                Board[boardLocation.X, boardLocation.Y].Value = pieceValue;
            }
        }

        #endregion


    }



}
