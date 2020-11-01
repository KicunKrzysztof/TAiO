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

        public override string ToString()
        {
            var text = string.Empty;
            foreach (var segment in Segments)
            {
                text += segment.ToString() + " ";
            }
            return text;
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
            return piece.Segments.Select(a => new Point(a.X - xDiff, a.Y - yDiff)).ToList();
        }

        public static Piece RotateRight(this Piece piece)
        {
            var rotatedSegments = piece.Segments.Select(a => new Point(piece.Size - a.Y - 1, a.X));
            if (rotatedSegments.Any(a => a.Y < 0))
            {
                int a = 3;
            }
            //var xMinCorrection = rotatedSegments.Min((a) => piece.Size - a.X);
            //var xMaxCorrection = rotatedSegments.Max((a) => piece.Size - a.X);
            //var yMinCorrection = rotatedSegments.Min((a) => piece.Size - a.Y);
            //var yMaxCorrection = rotatedSegments.Max((a) => piece.Size - a.Y);

            //var xCorrection = 0;
            //var yCorrection = 0;

            //if (xMinCorrection <= 0)
            //{
            //    xCorrection = xMinCorrection - 1;
            //}
            //else if (xMaxCorrection > piece.Size)
            //{
            //    xCorrection = xMaxCorrection - piece.Size;
            //}
            //if (yMinCorrection <= 0)
            //{
            //    yCorrection = yMinCorrection - 1;
            //}
            //else if (yMaxCorrection > piece.Size)
            //{
            //    yCorrection = yMaxCorrection - piece.Size;
            //}

            //rotatedSegments = rotatedSegments.Select(a => new Point(a.X + xCorrection, a.Y + yCorrection));

            return new Piece(rotatedSegments.ToList());
        }
     
    }
}
