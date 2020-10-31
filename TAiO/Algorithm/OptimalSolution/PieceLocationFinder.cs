using System.Collections.Generic;
using System.Linq;
using Algorithm;
using Algorithm.Model;

namespace TAiO
{
    public class PieceLocationFinder
    {
        /// <summary>
        /// WARN NIE PRZETESTOWANE
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentPiece"></param>
        /// <returns></returns>
        public List<Point> GetAvailableLocations(Board board, Piece currentPiece)
        {
            List<Point> availableLocations = new List<Point>();
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    var currentBoardSegment = board[i, j];
                    //F.4
                    if (IsLocationAvailable(board, currentBoardSegment, currentPiece))
                    {
                        availableLocations.Add(new Point(i, j));
                    }
                }
            }

            return availableLocations;
        }

        private bool IsLocationAvailable(Board board, BoardSegment segment, Piece piece)
        {
            if (segment.Value != 0)
            {
                return false;
            }
            // F.3 - wybierz dowolny segment s klocka k
            //wybor pierwszego kawalka 
            var startingPiecePoint = piece[0];

            foreach (var pieceSegment in piece.Segments.Where(a => a != startingPiecePoint))
            {
                //odleglosc segmentow klocka od segmentu wyroznionego
                var xDiff = startingPiecePoint.X - pieceSegment.X;
                var yDiff = startingPiecePoint.Y - pieceSegment.Y;

                //polozenie segmentu zmapowane na plansze
                var targetX = segment.Location.X + xDiff;
                var targetY = segment.Location.Y + yDiff;
                if (
                    targetX < 0 ||
                    targetX >= board.Size ||
                    targetY < 0 ||
                    targetY >= board.Size
                )
                {
                    return false;
                }

                //segment jest juz zajety
                if (board[targetX, targetY].Value != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}