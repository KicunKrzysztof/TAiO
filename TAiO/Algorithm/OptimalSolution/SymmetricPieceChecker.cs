using Algorithm.Model;

namespace TAiO
{
    public class SymmetricPieceChecker
    {
        public bool CheckIfAlreadyCheckedSymmetricRotation(int rotationIndex, Piece currentPiece,
            Piece[] pieceRotations)
        {
            bool alreadyCheckedSymmetricRotation = false;

            for (int previousRotation = 0; previousRotation < rotationIndex; previousRotation++)
            {
                if (currentPiece.Compare(pieceRotations[previousRotation]))
                {
                    alreadyCheckedSymmetricRotation = true;
                    break;
                }
            }

            return alreadyCheckedSymmetricRotation;
        }
    }
}