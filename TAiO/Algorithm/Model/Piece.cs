using System.Collections.Generic;

namespace Algorithm.Model
{
    public class Piece
    {
        public int Size => Segments.Count;


        public Piece(List<Point> segments)
        {
            Segments = segments;
        }
        public List<Point> Segments { get; }

        public Point this[int index] => Segments[index];

        public void RotateRight()
        {
            //TODO 
        }
    }
}
