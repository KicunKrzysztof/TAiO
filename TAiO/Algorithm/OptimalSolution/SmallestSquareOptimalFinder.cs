using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm;
using Algorithm.Model;

namespace TAiO
{
    public class SmallestSquareOptimalFinder
    {
        private readonly PieceLocationFinder pieceLocationFinder = new PieceLocationFinder();

        public List<int[,]> CalculateSolutions(List<Piece> pieces)
        {
            if (!arePiecesValid(pieces))
            {
                throw new Exception("Invalid input");
            }

            //1.1
            var solutions = new List<int[,]>();
            var boardSize = CalculateInitialBoardSize(pieces);
            var board = new Board(boardSize);




            return solutions;
        }
        private int CalculateInitialBoardSize(List<Piece> pieces)
        {
            var piecesArea = pieces.Aggregate(0, (area, piece) => area + piece.Size);
            return (int) Math.Ceiling(Math.Sqrt(piecesArea));
        }

        private bool arePiecesValid(List<Piece> pieces)
        {
            if (pieces == null)
            {
                return false;
            }

            if (pieces.Count == 0)
            {
                return true;
            }

            var firstPieceSize = pieces[0].Size;
            return pieces.All(a => a.Size == firstPieceSize);
        }

        private void F(Board board, List<Piece> pieces, int pieceIndex)
        {
            var currentPiece = pieces[pieceIndex];
            //F.1
            int rotationsCounter = 0;
            //F.2
            var availableLocations = new List<Point>();

            var availabeLocations = pieceLocationFinder.GetAvailableLocations(board, currentPiece);

            foreach (var availableLocation in availableLocations)
            {
                
            }
        }

        private void SetPieceOnBoard(Board board, Point location, Piece piece, int pieceValue)
        {
            var startingPiecePoint = piece[0];
            foreach (var pieceSegment in piece.Segments)
            {
                //odleglosc segmentow klocka od segmentu wyroznionego
                var xDiff = startingPiecePoint.X - pieceSegment.X;
                var yDiff = startingPiecePoint.Y - pieceSegment.Y;

               
                var targetX = location.X + xDiff;
                var targetY = location.Y + yDiff;

                board[targetX, targetY].Value = pieceValue;
            }
        }
    }
}
