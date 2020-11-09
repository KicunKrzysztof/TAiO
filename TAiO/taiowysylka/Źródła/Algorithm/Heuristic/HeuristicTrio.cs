using System;

namespace Algorithm.Heuristic
{
    /// <summary>
    /// Struktura danych wykorzystywana w algorytmie heurystycznym
    /// </summary>
    public class HeuristicTrio : IComparable<HeuristicTrio>
    {
        public Point Segment { get; }
        public int RotationCounter { get; }
        public int NeighbourCounter { get; }
        public HeuristicTrio(Point seg, int rotationCount, int neighborsCount)
        {
            Segment = seg;
            RotationCounter = rotationCount;
            NeighbourCounter = neighborsCount;
        }

        public int CompareTo(HeuristicTrio other)
        {
            if (NeighbourCounter < other.NeighbourCounter)
                return -1;
            if (NeighbourCounter > other.NeighbourCounter)
                return 1;
            return 0;
        }
    }
}
