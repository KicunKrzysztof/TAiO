﻿using System.Collections.Generic;
using Algorithm.Model;

namespace TAiO
{
    /// <summary>
    /// Klasa reprezentująca rozwiazanie jako zbior struktur opisujacych (nr polozonego klocka, jego obrot, lokalizacje na planszy i kolor)
    /// </summary>
    public class Solution
    {
        private int[,] board;
        private List<Piece> pieces;

        public Solution(int boardSize, SolutionRow[] solutionRows, List<Piece> initialSet)
        {
            this.solutionRows = solutionRows;
            BoardSize = boardSize;
            pieces = initialSet;
        }
        public SolutionRow[] solutionRows;

        public int BoardSize { get; }
        public int[,] Board
        {
            get
            {
                if (board == null)
                {
                    board = CalculateBoard();
                }
                return board;
            }

        }

        private int[,] CalculateBoard()
        {
            var newBoard = new int[BoardSize, BoardSize];
            foreach (var solutionRow in solutionRows)
            {
                var piece = pieces[solutionRow.PieceIndex];

                for (int i = 0; i < solutionRow.Rotation; i++)
                {
                    piece = piece.RotateRight();
                }

                var pieceBoardLocation = piece.GetBoardLocation(solutionRow.Location);
                foreach (var boardLocation in pieceBoardLocation)
                {
                    newBoard[boardLocation.X, boardLocation.Y] = solutionRow.PieceValue;
                }
            }

            return newBoard;
        }

    }
}