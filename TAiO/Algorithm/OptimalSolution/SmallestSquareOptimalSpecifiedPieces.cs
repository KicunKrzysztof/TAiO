using Algorithm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using TAiO;

namespace Algorithm.OptimalSolution
{
    public class SmallestSquareOptimalSpecifiedPieces : SmallestSquareFinder
    {
        private Stack<SolutionRow> solutionRows;
        private List<Solution> solutions;
        private readonly PieceLocationFinder pieceLocationFinder = new PieceLocationFinder();
        private Dictionary<Piece, int> specifiedPieces;
        private Dictionary<int, Piece> indexMapping;
        private Dictionary<int, int> countMapping;
        private Dictionary<(int, int), int> colorMapping;
        private int currentPieceValue;
        private int PieceCount => specifiedPieces.Sum((a) => a.Value);
        public SmallestSquareOptimalSpecifiedPieces(Dictionary<Piece, int> specifiedPieces)
        {
            this.specifiedPieces = specifiedPieces;

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

            currentPieceValue = 1;
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
                var cur = new SolutionRow[solutionRows.Count];

                foreach (var solution in solutions)
                {

                    var alreadyFound = CompareLists(solution.solutionRows.ToList(), solutionRows.ToList());
                    if (alreadyFound)
                    {
                        return;
                    }
                }


                solutionRows.CopyTo(cur, 0);
                solutions.Add(new Solution(Board.Size, cur, specifiedPieces.Keys.ToList()));
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
                for (int rotationIndex = 0; rotationIndex < 4; rotationIndex++)
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

                    currentPiece = currentPiece.RotateRight();
                }
            }


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

        public static bool CompareLists<T>(List<T> aListA, List<T> aListB)
        {
            if (aListA == null || aListB == null || aListA.Count != aListB.Count)
                return false;
            if (aListA.Count == 0)
                return true;
            Dictionary<T, int> lookUp = new Dictionary<T, int>();
            // create index for the first list
            for (int i = 0; i < aListA.Count; i++)
            {
                int count = 0;
                if (!lookUp.TryGetValue(aListA[i], out count))
                {
                    lookUp.Add(aListA[i], 1);
                    continue;
                }
                lookUp[aListA[i]] = count + 1;
            }
            for (int i = 0; i < aListB.Count; i++)
            {
                int count = 0;
                if (!lookUp.TryGetValue(aListB[i], out count))
                {
                    // early exit as the current value in B doesn't exist in the lookUp (and not in ListA)
                    return false;
                }
                count--;
                if (count <= 0)
                    lookUp.Remove(aListB[i]);
                else
                    lookUp[aListB[i]] = count;
            }
            // if there are remaining elements in the lookUp, that means ListA contains elements that do not exist in ListB
            return lookUp.Count == 0;
        }
    }


    
}
