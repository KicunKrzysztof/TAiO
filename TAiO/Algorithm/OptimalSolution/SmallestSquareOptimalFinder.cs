﻿using Algorithm;
using Algorithm.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TAiO
{
    public class SmallestSquareOptimalFinder : SmallestSquareFinder
    {
        private List<Piece> pieces;
        private Stack<SolutionRow> solutionRows;
        private List<Solution> solutions;
        private readonly PieceLocationFinder pieceLocationFinder = new PieceLocationFinder();
        private readonly SolutionComparer solutionComparer = new SolutionComparer();
        public SmallestSquareOptimalFinder(List<Piece> pieces)
        {
            this.pieces = pieces;
        }
        public override List<Solution> CalculateSolutions()
        {
            if (pieces == null || pieces.Count == 0)
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
                F(0);
                boardSize++;
            } while (!solutions.Any());

            return solutions;
        }

        #region Private methods
        private int CalculateInitialBoardSize()
        {
            var piecesArea = pieces.Aggregate(0, (area, piece) => area + piece.Size);
            return (int)Math.Ceiling(Math.Sqrt(piecesArea));
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

            for (int rotationIndex = 0; rotationIndex < 4; rotationIndex++)
            {
                var availableLocations = pieceLocationFinder.GetAvailableLocations(Board, currentPiece);
                foreach (var availableLocation in availableLocations)
                {
                    var pieceValue = pieceIndex + 1;
                    solutionRows.Push(new SolutionRow(pieceIndex, new Point(availableLocation.X, availableLocation.Y), rotationIndex,pieceValue));
                    SetPieceOnBoard(availableLocation, currentPiece, pieceValue);
                    F(pieceIndex + 1);
                    SetPieceOnBoard(availableLocation, currentPiece, 0);
                    solutionRows.Pop();
                    //Board.ToConsole();
                }
                currentPiece = currentPiece.RotateRight();
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
    }
}
