using System;

namespace Algorithm.Model
{
    /// <summary>
    /// Plansza skladajaca sie z segmentow, na ktorej kladzie sie klocki
    /// </summary>
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
        public Board(int[,] arr)
        {
            Segments = new BoardSegment[arr.GetLength(0), arr.GetLength(0)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    Segments[i, j] = new BoardSegment(i, j);
                    Segments[i, j].Value = arr[i, j];
                }
            }
        }
        public BoardSegment this[int index1, int index2] => Segments[index1, index2];
    }

    /// <summary>
    /// Metody rozszerzające
    /// </summary>
    public static class BoardExt
    {
        public static void ToConsole(this Board board)
        {
            var segments = board.Segments;
            Console.WriteLine("########");
            
            for (int i = 0; i < board.Size; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < board.Size; j++)
                {
                    Console.Write($" {segments[i,j].Value}");
                }
            }
            Console.WriteLine();
        }
        public static Board ExtendBoard(this Board board)
        {
            var extended_arr = new int[board.Size + 1, board.Size + 1];
            for (int i = 0; i < board.Size + 1; i++)
            {
                for (int j = 0; j < board.Size + 1; j++)
                {
                    extended_arr[i, j] = 0;
                    if (i < board.Size && j < board.Size)
                        extended_arr[i,j] = board.Segments[i, j].Value;
                }
            }
            return new Board(extended_arr);
        }
    }
}
