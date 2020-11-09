using System;
using System.Diagnostics;

namespace Algorithm.Model
{
    public class BoardSegment
    {
        public Point Location { get; set; }
        public BoardSegment(int x, int y)
        {
            Location = new Point(x,y);
            Value = 0;
        }
        /// 0 jesli pusty, id klocka w przeciwnym wypadku
        /// </summary>
        public int Value { get; set; }
    }

    public static class BoardSegmentExtensions
    {
   
        public static int[,] ToPrintableMatrix(this BoardSegment[,] board)
        {
            var size = board.GetLength(0);
            int[,] matrix = new int[size,size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i,j] = board[i, j].Value;
                }
            }
            return matrix;
        }


       
    }
}