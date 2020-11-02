using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm;
using Algorithm.Heuristic;
using Algorithm.Model;

namespace TAiO
{
    public class SmallestSquareOptimalFinder : SmallestSquareFinder
    {

        private readonly PieceLocationFinder pieceLocationFinder = new PieceLocationFinder();
        public SmallestSquareOptimalFinder()
        {
            this.Pieces = new List<Piece>();
        }

        public override List<int[,]> CalculateSolutions()
        {
            if (!ArePiecesValid())
            {
                throw new Exception("Invalid input");
            }

            //1.1
            Solutions = new List<int[,]>();
            var boardSize = CalculateInitialBoardSize();
            do
            {
                Board = new Board(boardSize);
                F(0, Solutions);
                boardSize++;
            } while (!Solutions.Any());

            return Solutions;
        }

        #region Private methods
        private int CalculateInitialBoardSize()
        {
            var piecesArea = Pieces.Aggregate(0, (area, piece) => area + piece.Size);
            return (int)Math.Ceiling(Math.Sqrt(piecesArea));
        }
        private bool ArePiecesValid()
        {
            if (Pieces == null)
            {
                return false;
            }

            if (Pieces.Count == 0)
            {
                return true;
            }

            var firstPieceSize = Pieces[0].Size;
            return Pieces.All(a => a.Size == firstPieceSize);
        }
        private void F(int pieceIndex, List<int[,]> Solutions)
        {
            if (pieceIndex >= Pieces.Count)
            {
                Solutions.Add(Board.Segments.ToPrintableMatrix());
                return;
            }

            var currentPiece = Pieces[pieceIndex];
            //F.1
            //F.2 - F.4
            
            for (int i = 0; i < 4; i++)
            {
                var availableLocations = pieceLocationFinder.GetAvailableLocations(Board, currentPiece);
                foreach (var availableLocation in availableLocations)
                {

                    SetPieceOnBoard(availableLocation, currentPiece, pieceIndex + 1);
                    // Board.ToConsole();
                    F(pieceIndex + 1, Solutions);
                    SetPieceOnBoard(availableLocation, currentPiece, 0);
                    //Board.ToConsole();
                }
                currentPiece = currentPiece.RotateRight();
            }
            
        }
        private void SetPieceOnBoard(Point location, Piece piece, int pieceValue)
        {
            var pieceBoardLocation = piece.GetBoardLocation(location);
            foreach (var boardLocation in pieceBoardLocation)
            {
                Board[boardLocation.X, boardLocation.Y].Value = pieceValue;
            }
        }

        #endregion
    }

    public abstract class SmallestSquareFinder
    {
        public List<Piece> Pieces { get; set; }
        public Board Board { get; protected set; }
        public List<int[,]> Solutions = new List<int[,]>();

        public abstract List<int[,]> CalculateSolutions();
    }
}
