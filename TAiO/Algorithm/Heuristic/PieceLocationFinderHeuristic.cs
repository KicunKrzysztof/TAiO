using Algorithm.Model;
using System.Collections.Generic;

namespace Algorithm.Heuristic
{
    public class PieceLocationFinderHeuristic
    {
        /// <summary>
        /// Zwraca liste dostepnych polozen dla danego klocka o danym obrocie
        /// </summary>
        /// <param name="board"></param>
        /// <param name="piece"></param>
        /// <param name="rotationCount"></param>
        /// <returns></returns>
        public List<HeuristicTrio> FindPossibleLocations(Board board, Piece piece, int rotationCount)
        {
            var resList = new List<HeuristicTrio>();
            for (int i = 0; i < board.Size; i++)
                for(int j = 0; j < board.Size; j++)
                {
                    var pieceLocations = PieceExtensions.GetBoardLocation(piece, new Point(i, j));
                    if (!ValidateLocation(board, pieceLocations))
                        continue;
                    int neighbourCount = GetNeighbourCount(board, pieceLocations);
                    resList.Add(new HeuristicTrio(new Point(i, j), rotationCount, neighbourCount));
                }
            return resList;
        }
        private bool ValidateLocation(Board board, List<Point> piece_location_list)
        {
            foreach(Point p in piece_location_list)
            {
                if ((!PieceOnBoard(board, p)) || board[p.X, p.Y].Value != 0)
                    return false;
            }
            return true;
        }
        private int GetNeighbourCount(Board board, List<Point> piece_location_list)
        {
            int counter = 0;
            foreach (Point p in piece_location_list)
            {
                if (PieceOnBoard(board, new Point(p.X + 1, p.Y)) && board[p.X + 1, p.Y].Value != 0)
                    counter++;
                if (PieceOnBoard(board, new Point(p.X - 1, p.Y)) && board[p.X - 1, p.Y].Value != 0)
                    counter++;
                if (PieceOnBoard(board, new Point(p.X, p.Y + 1)) && board[p.X, p.Y + 1].Value != 0)
                    counter++;
                if (PieceOnBoard(board, new Point(p.X, p.Y - 1)) && board[p.X, p.Y - 1].Value != 0)
                    counter++;
            }
            return counter;
        }
        private bool PieceOnBoard(Board board, Point point)
        {
            return !(point.X < 0 || point.X >= board.Size || point.Y < 0 || point.Y >= board.Size);
        }
    }
}