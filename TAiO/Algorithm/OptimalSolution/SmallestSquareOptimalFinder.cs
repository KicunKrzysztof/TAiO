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
        public SmallestSquareOptimalFinder(List<Piece> pieces)
        {
            this.pieces = pieces;
        }

        private List<Piece> pieces;
        public Board Board { get; private set; }

        public EventHandler OnBoardUpdate;
        public List<int[,]> Solutions = new List<int[,]>();
        /// <summary>
        /// zapisuje informacje o ulozeniu klockow w danym rozwiazaniu - do sprawdzenia czy juz znalezlismy takie rozwiazanie
        /// </summary>
        public List<(int pieceIndex, Point firstElementLocation, int rotation)> solutionNiemampomyslunanazwe;
        private readonly PieceLocationFinder pieceLocationFinder = new PieceLocationFinder();

        public List<int[,]> CalculateSolutions()
        {
            if (!arePiecesValid())
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
            var piecesArea = pieces.Aggregate(0, (area, piece) => area + piece.Size);
            return (int)Math.Ceiling(Math.Sqrt(piecesArea));
        }

        private bool arePiecesValid()
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

        private void F(int pieceIndex, List<int[,]> Solutions)
        {
            if (pieceIndex >= pieces.Count)
            {
                Solutions.Add(Board.Segments.ToPrintableMatrix());
                return;
            }

            var currentPiece = pieces[pieceIndex];
            //F.1
            int rotationsCounter = 0;
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
            

           // var copy = Board.Segments.ToPrintableMatrix().Clone() as int[,]; 
           //OnBoardUpdate?.Invoke(copy, null);


            var pieceBoardLocation = piece.GetBoardLocation(location);
            foreach (var boardLocation in pieceBoardLocation)
            {
                Board[boardLocation.X, boardLocation.Y].Value = pieceValue;
            }
        }

        #endregion
    }
}
