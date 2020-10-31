using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.PiecesGenerators;

namespace Algorithm.Model
{
    public class Board
    {
        public BoardSegment[,] Segments { get; }


        public int Size => Segments.GetLength(0);
        public Board(int size)
        {
            Segments = new BoardSegment[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Segments[i, j] = new BoardSegment(i, j);
                }
            }
        }

        public BoardSegment this[int index1, int index2] => Segments[index1, index2];
    }
}
