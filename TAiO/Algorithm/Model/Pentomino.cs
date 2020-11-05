using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Model
{
    public class Pentomino: PredefinedPieces
    {
        private List<Piece> pentominos;
        public Pentomino()
        {
            pentominos = new List<Piece>();
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(4, 0)})); //1
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(0, 2), new Point(1, 0), new Point(1, 1), new Point(2, 1)})); //2
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 2), new Point(2, 1)})); //3
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(3, 0), new Point(3, 1)})); //4
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(3, 1)})); //5
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(2, 1)})); //6
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(2, 0)})); //7
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(1, 1), new Point(2, 0), new Point(2, 1), new Point(3, 0)})); //8
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(2, 1), new Point(3, 1)})); //9
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(0, 2), new Point(1, 1), new Point(2, 1)})); //10
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 2), new Point(1, 0), new Point(1, 1), new Point(1, 2)})); //11
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 2), new Point(1, 2), new Point(2, 0), new Point(2, 1), new Point(2, 2)})); //12
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 2), new Point(1, 1), new Point(1, 2), new Point(2, 0), new Point(2, 1)})); //13
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(2, 1)})); //14
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(2, 1), new Point(3, 1)})); //15
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(1, 1)})); //16
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(0, 2), new Point(1, 1), new Point(2, 0), new Point(2, 1)})); //17
            pentominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(2, 2)})); //18
        }
        override public List<Piece> GeneratePieces(List<int> n_list)
        {
            if (n_list.Count > 18)
                return null;
            var generated_pieces = new List<Piece>();
            for (int n = 0; n < n_list.Count; n++)
            {
                for (int i = 0; i < n_list[n]; i++)
                    generated_pieces.Add(pentominos[n].DeepCopy());
            }
            return generated_pieces;
        }
    }
}
