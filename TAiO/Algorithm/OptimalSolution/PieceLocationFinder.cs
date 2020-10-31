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
                    //F.4
                    if (IsLocationAvailable(board, board[i,j].Location, currentPiece))
                    {
                        availableLocations.Add(new Point(i, j));
                    }
                }
            }

            return availableLocations;
        }

        private bool IsLocationAvailable(Board board, Point location, Piece piece)
        {
            if (board[location.X, location.Y].Value != 0)
            {
                return false;
            }

            var boardPieceLocation = piece.GetBoardLocation(location);
            foreach (var boardLocation in boardPieceLocation)
            {
                if (
                    boardLocation.X < 0 ||
                    boardLocation.X >= board.Size ||
                    boardLocation.Y < 0 ||
                    boardLocation.Y >= board.Size ||
                    //location jest juz zajety
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