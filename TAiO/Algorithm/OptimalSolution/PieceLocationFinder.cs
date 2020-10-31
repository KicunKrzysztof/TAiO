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

            var boardPieceLocation = piece.GetBoardLocation(segment.Location);
            foreach (var boardLocation in boardPieceLocation)
            {
                if (
                    boardLocation.X < 0 ||
                    boardLocation.X >= board.Size ||
                    boardLocation.Y < 0 ||
                    boardLocation.Y >= board.Size ||
                    //segment jest juz zajety
                    board[boardLocation.X, boardLocation.Y].Value != 0
                )
                {
                    return false;
                }
            }
           
            return true;
        }
    }
}