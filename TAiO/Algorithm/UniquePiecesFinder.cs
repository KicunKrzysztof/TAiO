using Algorithm.Model;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class UniquePiecesFinder
    {
        public Dictionary<Piece, int> FindUniquePieces(List<Piece> pieces)
        {
            var piecesCount = new Dictionary<Piece, int>();

            foreach (var piece in pieces)
            {
                var foundPiece = piecesCount.Keys.FirstOrDefault(a => a.Compare(piece));
                if (foundPiece == null)
                {
                    piecesCount.Add(piece, 1);
                }
                else
                {
                    piecesCount[foundPiece] = piecesCount[foundPiece] + 1;
                }
            }

            return piecesCount;
        }
    }
}
