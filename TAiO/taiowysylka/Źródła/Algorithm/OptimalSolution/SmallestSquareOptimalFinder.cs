using Algorithm;
using Algorithm.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TAiO
{
    /// <summary>
    /// Wersja algorytmu, dla ktorego kazdy klocek jest unikalny - robocza pozostalosc 
    /// </summary>
    public class SmallestSquareOptimalFinder : SmallestSquareFinder
    {
        private readonly int availableRotations = 4;
        private readonly List<Piece> pieces;
        private Stack<SolutionRow> solutionRows;
        private List<Solution> solutions;
        private readonly PieceLocationFinder pieceLocationFinder = new PieceLocationFinder();
        private readonly SymmetricPieceChecker symmetricPieceChecker;

        public SmallestSquareOptimalFinder(List<Piece> pieces)
        {
            this.pieces = pieces;
            symmetricPieceChecker = new SymmetricPieceChecker();
        }
        public override List<Solution> CalculateSolutions()
        {
            if (pieces == null || pieces.Count == 0)
            {
                return new List<Solution>();
            }
            solutions = new List<Solution>();
            solutionRows = new Stack<SolutionRow>();

            //1.1 - Wyznacz początkowy rozmiar planszy
            var boardSize = CalculateInitialBoardSize();
            do
            {
                Board = new Board(boardSize);
                F(0);
                boardSize++;
                //jesli nie znaleziono rozwiazania to zwieksz plansze i kontynuuj
            } while (!solutions.Any());

            return solutions;
        }
        private void F(int pieceIndex)
        {
            if (pieceIndex >= pieces.Count)
            {
                // var currentSolution = Board.Segments.ToPrintableMatrix();
                var cur = new SolutionRow[solutionRows.Count];
                solutionRows.CopyTo(cur, 0);
                solutions.Add(new Solution(Board.Size, cur, pieces));
                return;
            }

            var currentPiece = pieces[pieceIndex];
            //F.1
            //F.2 - F.4
            Piece[] pieceRotations = new Piece[availableRotations];

            for (int rotationIndex = 0; rotationIndex < availableRotations; rotationIndex++)
            {
                pieceRotations[rotationIndex] = currentPiece;
                var alreadyCheckedSymmetricRotation = symmetricPieceChecker.CheckIfAlreadyCheckedSymmetricRotation(rotationIndex, currentPiece, pieceRotations);

                if (!alreadyCheckedSymmetricRotation)
                {
                    var availableLocations = pieceLocationFinder.GetAvailableLocations(Board, currentPiece);
                    foreach (var availableLocation in availableLocations)
                    {
                        var pieceValue = pieceIndex + 1;
                        solutionRows.Push(new SolutionRow(pieceIndex,
                            new Point(availableLocation.X, availableLocation.Y), rotationIndex, pieceValue));
                        SetPieceOnBoard(availableLocation, currentPiece, pieceValue);
                        F(pieceIndex + 1);
                        SetPieceOnBoard(availableLocation, currentPiece, 0);
                        solutionRows.Pop();
                    }
                }
                currentPiece = currentPiece.RotateRight();
            }
        }
        #region Helper methods
        private int CalculateInitialBoardSize()
        {
            var piecesArea = pieces.Aggregate(0, (area, piece) => area + piece.Size);
            return (int)Math.Ceiling(Math.Sqrt(piecesArea));
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
