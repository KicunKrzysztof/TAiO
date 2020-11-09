using Algorithm.Model;

namespace TAiO
{
    public class SymmetricPieceChecker
    {
        /// <summary>
        /// Sprawdza czy dany obrot klocka byl juz sprawdzany. Obsluguje sytuacje kiedy klocki są symetryczne
        /// </summary>
        /// <param name="rotationIndex"></param>
        /// <param name="currentPiece"></param>
        /// <param name="pieceRotations"></param>
        /// <returns></returns>
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