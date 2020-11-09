using Algorithm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using TAiO;

namespace Algorithm.OptimalSolution
{
    public class SmallestSquareOptimalSpecifiedPieces : SmallestSquareFinder
    {
        private readonly SymmetricPieceChecker symmetricPieceChecker = new SymmetricPieceChecker();
        private readonly PieceLocationFinder pieceLocationFinder = new PieceLocationFinder();

        private Stack<SolutionRow> solutionRows;
        private List<Solution> solutions;

        private Dictionary<Piece, int> specifiedPieces;
        private Dictionary<int, Piece> indexMapping;
        private Dictionary<int, int> countMapping;
        private Dictionary<(int, int), int> colorMapping;
        private int PieceCount => specifiedPieces.Sum((a) => a.Value);

        public SmallestSquareOptimalSpecifiedPieces(List<Piece> pieces)
        {
            var uniquePiecesFinder = new UniquePiecesFinder();
            specifiedPieces = uniquePiecesFinder.FindUniquePieces(pieces);
            InitializeMappings();
        }

        public SmallestSquareOptimalSpecifiedPieces(Dictionary<Piece, int> specifiedPieces)
        {
            this.specifiedPieces = specifiedPieces;
            InitializeMappings();
        }

        private void InitializeMappings()
        {
            int index = 0;
            indexMapping = specifiedPieces.Keys.ToList().ToDictionary(a => index++);
            index = 0;
            countMapping = specifiedPieces.Values.ToList().ToDictionary(a => index++);

            int colorIndex = 1;
            colorMapping = new Dictionary<(int, int), int>();
            for (int typeIndex = 0; typeIndex < this.specifiedPieces.Count; typeIndex++)
            {
                for (int i = 0; i < countMapping[typeIndex]; i++)
                {
                    colorMapping.Add((typeIndex, i), colorIndex);
                    colorIndex++;
                }
            }
        }

        public override List<Solution> CalculateSolutions()
        {
            if (specifiedPieces == null || specifiedPieces.Count == 0)
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

            return solutions;
        }

        #region Private methods
        private int CalculateInitialBoardSize()
        {
            var piecesArea = PieceCount * specifiedPieces.FirstOrDefault().Key.Size;
            return (int)Math.Ceiling(Math.Sqrt(piecesArea));
        }
        private void F(int pieceTypeIndex, int currentTypeCount)
        {
            if (pieceTypeIndex >= specifiedPieces.Keys.Count)
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

        private void AddCurrentSolution()
        {
            var cur = new SolutionRow[solutionRows.Count];
            solutionRows.CopyTo(cur, 0);
            solutions.Add(new Solution(Board.Size, cur, specifiedPieces.Keys.ToList()));
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
