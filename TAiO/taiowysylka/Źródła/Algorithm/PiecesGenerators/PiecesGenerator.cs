using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Model;
using Algorithm.PiecesGenerators;

namespace Algorithm
{
    public class PiecesGenerator
    {
        #region Private fields
        private Random random;
        private LocationFinder locationFinder;
        #endregion

        public PiecesGenerator()
        {
            random = new Random();
            locationFinder = new LocationFinder();
        }

        #region Public methods
        /// /// <summary>
        /// Zwraca listę klocków przedstawianych jako tablica punktów.
        /// Punkty są współrzędnymi segmentów klocka na planszy o wymiarach n x n
        /// gdzie n - wymiar klocka.
        /// </summary>
        /// <param name="piecesCount">Liczba klocków do wygenerowania</param>
        /// <param name="pieceSize">Rozmiar klocków do wygenerowania</param>
        /// <returns></returns>
        public List<Piece> GeneratePieces(int piecesCount, int pieceSize)
        {
            var pieces = new List<Point[]>();

            for (int i = 0; i < piecesCount; i++)
            {
                var piece = new Point[pieceSize];
                var startingPoint = GetRandomPoint(pieceSize, pieceSize);
                piece[0] = startingPoint;

                for (int j = 1; j < pieceSize; j++)
                {
                    var availableLocations = locationFinder.FindAvailableLocations(piece, pieceSize, pieceSize);
                    piece[j] = availableLocations[random.Next(availableLocations.Count)];
                }
                pieces.Add(piece);
            }
            return pieces.Select(segments => new Piece(segments.ToList())).ToList();
        }
        #endregion

        #region Private methods
        private Point GetRandomPoint(int maxX, int maxY)
        {
            var x = random.Next(0, maxX);
            var y = random.Next(0, maxY);
            return new Point(x, y);
        }

        #endregion


    }

}
