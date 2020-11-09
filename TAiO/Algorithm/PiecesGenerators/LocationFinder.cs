using System.Collections.Generic;
using System.Linq;

namespace Algorithm.PiecesGenerators
{
    /// <summary>
    /// Zwraca liste pol na ktore mozna rozszerzyc aktualnie generowany klocek
    /// </summary>
    class LocationFinder
    {
        public List<Point> FindAvailableLocations(Point[] previousPoints, int maxX, int maxY)
        {
            List<Point> availableLocations = new List<Point>();

            previousPoints = previousPoints.Where(a => a != null).ToArray();

            foreach (var point in previousPoints)
            {
                var theoreticalPoints = new List<Point>
                {
                    new Point(point.X + 1, point.Y),
                    new Point(point.X - 1, point.Y),
                    new Point(point.X , point.Y + 1),
                    new Point(point.X , point.Y - 1),
                };
                foreach (var theoreticalPoint in theoreticalPoints)
                {
                    if (
                        theoreticalPoint.X >= 0 &&
                        theoreticalPoint.X < maxX &&
                        theoreticalPoint.Y >= 0 &&
                        theoreticalPoint.Y < maxY &&
                        !previousPoints.Contains(theoreticalPoint))
                    {
                        if (!availableLocations.Contains(theoreticalPoint))
                        {
                            availableLocations.Add(theoreticalPoint);
                        }
                    }
                }
            }
            return availableLocations;
        }
    }
}
