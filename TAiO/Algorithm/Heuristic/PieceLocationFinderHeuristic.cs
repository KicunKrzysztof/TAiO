using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Model;

namespace Algorithm.Heuristic
{
    public class PieceLocationFinderHeuristic
    {
        public List<HeuristicTrio> FindPossibleLocations(Board board, Piece piece, int rotation_count)
        {
            var res_list = new List<HeuristicTrio>();
            for (int i = 0; i < board.Size; i++)
                for(int j = 0; j < board.Size; j++)
                {
                    var piece_location_list = PieceExtensions.GetBoardLocation(piece, new Point(i, j));
                    if (!ValidateLocation(board, piece_location_list))
                        continue;
                    int neighbour_count = GetNeighbourCount(board, piece_location_list);
                    res_list.Add(new HeuristicTrio(new Point(i, j), rotation_count, neighbour_count));
                }
            return res_list;
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