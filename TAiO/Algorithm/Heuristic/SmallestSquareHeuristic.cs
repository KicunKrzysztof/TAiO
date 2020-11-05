using Algorithm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using TAiO;

namespace Algorithm.Heuristic
{
    public class SmallestSquareHeuristic : SmallestSquareFinder
    {
        private readonly PieceLocationFinderHeuristic locationFinder = new PieceLocationFinderHeuristic();
        public SmallestSquareHeuristic()
        {
            this.Pieces = new List<Piece>();
        }

        public override List<int[,]> CalculateSolutions()
        {
            if (Pieces == null || Pieces.Count == 0)
            {
                return new List<int[,]>();
            }
            Board = new Board(CalculateInitialBoardSize());
            SetFirstPiece();
            for (int i = 1; i < Pieces.Count; i++)
            {
                int r = 0;
                var L = new List<HeuristicTrio>();
                while (true)
                {
                    L = L.Concat(locationFinder.FindPossibleLocations(Board, Pieces[i], r)).ToList();
                    Pieces[i] = Pieces[i].RotateRight();
                    r++;
                    if (r == 4)
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
                {
                    Pieces[i] = Pieces[i].RotateRight();
                }
                    
                SetPiece(Pieces[i], best_location.Segment, i + 1);
            }

            return new List<int[,]> { Board.Segments.ToPrintableMatrix() };
        }

        private int CalculateInitialBoardSize()
        {
            var piecesArea = Pieces.Aggregate(0, (area, piece) => area + piece.Size);
            return (int)Math.Ceiling(Math.Sqrt(piecesArea));
        }
        private void SetFirstPiece()
        {
            Point location = PieceExtensions.FindFirstLocationHeuristic(Pieces[0]);
            var pieceBoardLocation = Pieces[0].GetBoardLocation(location);
            foreach (var boardLocation in pieceBoardLocation)
            {
                if (boardLocation.X >= Board.Size || boardLocation.Y >= Board.Size)
                    Board = BoardExt.ExtendBoard(Board);
                Board[boardLocation.X, boardLocation.Y].Value = 1;
            }
        }
        private void SetPiece(Piece p, Point location, int value)
        {
            var piece_location_list = PieceExtensions.GetBoardLocation(p, location);
            foreach (Point segment in piece_location_list)
            {
                Board.Segments[segment.X, segment.Y].Value = value;
            }
        }
    }

    public interface ISmallestSquareFinder
    {
        List<int[,]> CalculateSolutions();
    }
}
