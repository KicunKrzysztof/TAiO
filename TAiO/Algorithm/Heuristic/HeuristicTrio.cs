using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Heuristic
{
    public class HeuristicTrio : IComparable<HeuristicTrio>
    {
        public Point Segment { get; private set; }
        public int RotationCounter { get; private set; }
        public int NeighbourCounter { get; private set; }
        public HeuristicTrio(Point seg, int rot_count, int neigh_count)
        {
            Segment = seg;
            RotationCounter = rot_count;
            NeighbourCounter = neigh_count;

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
