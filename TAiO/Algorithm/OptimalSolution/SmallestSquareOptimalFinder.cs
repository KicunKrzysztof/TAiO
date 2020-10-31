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

        private readonly PieceLocationFinder pieceLocationFinder = new PieceLocationFinder();
        

        public List<int[,]> CalculateSolutions(List<Piece> pieces)
        {
            if (!arePiecesValid(pieces))
            {
                throw new Exception("Invalid input");
            }

            //1.1
            var solutions = new List<int[,]>();
            var boardSize = CalculateInitialBoardSize(pieces);
            do
         {
             var board = new Board(boardSize);
                F(board, pieces, 0, solutions);
                boardSize++;
          } while (!solutions.Any());

            return solutions;
        }
        private int CalculateInitialBoardSize(List<Piece> pieces)
        {
            var piecesArea = pieces.Aggregate(0, (area, piece) => area + piece.Size);
            return (int) Math.Ceiling(Math.Sqrt(piecesArea));
        }

        private bool arePiecesValid(List<Piece> pieces)
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

        private void F(Board board, List<Piece> pieces, int pieceIndex, List<int[,]> solutions)
        {
            if (pieceIndex >= pieces.Count)
            {
                solutions.Add(board.Segments.ToPrintableMatrix());
                return;
            }

            var currentPiece = pieces[pieceIndex];
            //F.1
            int rotationsCounter = 0;
            //F.2 - F.4
            var availableLocations = pieceLocationFinder.GetAvailableLocations(board, currentPiece);

            foreach (var availableLocation in availableLocations)
            {
                SetPieceOnBoard(board, availableLocation, currentPiece, pieceIndex + 1);
                F(board, pieces, pieceIndex + 1, solutions);
                SetPieceOnBoard(board, availableLocation, currentPiece, 0);
            }
        }

        private void SetPieceOnBoard(Board board, Point location, Piece piece, int pieceValue)
        {
            var pieceBoardLocation = piece.GetBoardLocation(location);
            foreach (var boardLocation in pieceBoardLocation)
            {
                board[boardLocation.X, boardLocation.Y].Value = pieceValue;
            }
        }
    }
}
