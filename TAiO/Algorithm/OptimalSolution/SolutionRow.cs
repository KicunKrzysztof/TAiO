using Algorithm;

namespace TAiO
{
    public class SolutionRow
    {
        public int PieceIndex { get; }
        public Point Location { get; }
        public int Rotation { get; }
        public int PieceValue { get; }

        public SolutionRow(int pieceIndex, Point location, int rotation, int pieceValue)
        {
            PieceIndex = pieceIndex;
            Location = location;
            Rotation = rotation;
            PieceValue = pieceValue;
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var other = (SolutionRow) obj;
            return PieceIndex == other.PieceIndex && Equals(Location, other.Location) && Rotation == other.Rotation;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = PieceIndex;
                hashCode = (hashCode * 397) ^ (Location != null ? Location.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Rotation;
                return hashCode;
            }
        }
    }
}