using Algorithm.Model;

namespace TAiO
{
    public class GeneratorMapper
    {
        public static PredefinedPieces Map(int pieceSize)
        {
            switch (pieceSize)
            {
                case 5:
                    return new Pentomino();
                case 6:
                    return new Hexomino();
                default:
                    return null;
            }
        }
    }
}