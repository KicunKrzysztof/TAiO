using Algorithm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using TAiO;

namespace Algorithm.Heuristic
{
    /// <summary>
    /// Algorytm heurystyczny
    /// </summary>
    public class SmallestSquareHeuristic : SmallestSquareFinder
    {
        private List<Piece> pieces;
        private readonly PieceLocationFinderHeuristic locationFinder = new PieceLocationFinderHeuristic();
        private List<SolutionRow> solutionRows;
        public SmallestSquareHeuristic(List<Piece> pieces)
        {
            this.pieces = pieces;
        }

        public override List<Solution> CalculateSolutions()
        {
            if (pieces == null || pieces.Count == 0)
            {
                return new List<Solution>();
            }

            solutionRows = new List<SolutionRow>();
            Board = new Board(CalculateInitialBoardSize());
            SetFirstPiece();

            for (int i = 1; i < pieces.Count; i++)
            {
                var currentPiece = pieces[i];
                int r = 0;
                var L = new List<HeuristicTrio>();
                while (true)
                {
                    L = L.Concat(locationFinder.FindPossibleLocations(Board, currentPiece, r)).ToList();
                    currentPiece = currentPiece.RotateRight();
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
                    currentPiece = currentPiece.RotateRight();
                }
                solutionRows.Add(new SolutionRow(i, best_location.Segment, best_location.RotationCounter, i + 1));
                SetPiece(currentPiece, best_location.Segment, i + 1);
            }

            return new List<Solution>() { new Solution(Board.Size, solutionRows.ToArray(), pieces) };
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
                if (boardLocation.X >= Board.Size || boardLocation.Y >= Board.Size)
                    Board = BoardExt.ExtendBoard(Board);
                Board[boardLocation.X, boardLocation.Y].Value = 1;
            }
            solutionRows.Add(new SolutionRow(0, location, 0, 1));
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
}
