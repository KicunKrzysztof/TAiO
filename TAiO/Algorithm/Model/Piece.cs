using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Model
{
    public class Piece
    {
        public int Size => Segments.Count;
        public Piece(List<Point> segments)
        {
            Segments = segments;
        }
        /// <summary>
        /// Opisuje ulozenie klocka na kwadracie size x size - "w prozni"
        /// </summary>
        public List<Point> Segments { get; }

        public Point this[int index] => Segments[index];

        public void RotateRight()
        {
            //TODO 
        }
    }

    public static class PieceExtensions
    {
        /// <summary>
        /// Zwraca ulozenie klocka na planszy 
        /// </summary>
        /// <param name="firstSegmentLocation">Wspolrzedna na planszy pierwszego segmentu klocka</param>
        /// <returns>Przemapowane ulozenie klocka na wspolrzedne mapy</returns>
        public static List<Point> GetBoardLocation(this Piece piece, Point firstSegmentLocation)
        {
            var startingPiecePoint = piece.Segments[0];

            //odleglosc segmentow klocka od segmentu wyroznionego
            var xDiff = startingPiecePoint.X - firstSegmentLocation.X;
            var yDiff = startingPiecePoint.Y - firstSegmentLocation.Y;
            return piece.Segments.Select(a => new Point(a.X + xDiff, a.Y + yDiff)).ToList();
        }
    }
}
