using System;
using System.Diagnostics;

namespace Algorithm.Model
{
    /// <summary>
    /// Fragment planszy okreslony przez lokalizacje i wartosc elementu, 0 - element bez klocka
    /// </summary>
    public class BoardSegment
    {
        public Point Location { get; set; }
        public BoardSegment(int x, int y)
        {
            Location = new Point(x,y);
            Value = 0;
        }

        public int Value { get; set; }
    }
}