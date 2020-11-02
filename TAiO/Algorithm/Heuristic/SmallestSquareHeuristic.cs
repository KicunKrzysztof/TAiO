using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm;
using Algorithm.Model;

namespace Algorithm.Heuristic
{
    public class SmallestSquareHeuristic
    {
        public SmallestSquareHeuristic(List<Piece> pieces)
        {
            this.pieces = pieces;
        }

        private List<Piece> pieces;
        public Board Board { get; private set; }
        public PieceLocationFinderHeuristic locationFinder = new PieceLocationFinderHeuristic();

        public int[,] CalculateSolution()
        {
            foreach(Piece p in pieces)
            {
                Console.WriteLine(p.ToString());
            }
            Board = new Board(CalculateInitialBoardSize());
            SetFirstPiece();
            BoardExt.ToConsole(Board);
            for (int i = 1; i < pieces.Count; i++)
            {
                int r = 0;
                var L = new List<HeuristicTrio>();
                while (true)
                {
                    L = L.Concat(locationFinder.FindPossibleLocations(Board, pieces[i], r)).ToList();
                    pieces[i].RotateRight();
                    r++;
                    if (r == 3)
                    {
                        if (L.Count > 0)
                        {
                            break;
                        }
                        else
                        {
                            r = 0;
                            Board = BoardExt.ExtendBoard(Board);
                        }
                    }
                }
                var best_location = L.Max();
                for (int k = 0; k < best_location.RotationCounter; k++)
                    pieces[i].RotateRight();
                SetPiece(pieces[i], best_location.Segment, i+1);
                BoardExt.ToConsole(Board);
            }
            return Board.Segments.ToPrintableMatrix();
        }

        private int CalculateInitialBoardSize()
        {
            var piecesArea = pieces.Aggregate(0, (area, piece) => area + piece.Size);
            return (int)Math.Ceiling(Math.Sqrt(piecesArea));
        }
        private void SetFirstPiece()
        {
            Point location = PieceExtensions.FindFirstLocationHeuristic(pieces[0]);
            var pieceBoardLocation = pieces[0].GetBoardLocation(location);
            foreach (var boardLocation in pieceBoardLocation)
            {
                Board[boardLocation.X, boardLocation.Y].Value = 1;
            }
        }
        private void SetPiece(Piece p, Point location, int value)
        {
            var piece_location_list = PieceExtensions.GetBoardLocation(p, location);
            foreach(Point segment in piece_location_list)
            {
                Board.Segments[segment.X, segment.Y].Value = value;
            }
        }
    }
}
