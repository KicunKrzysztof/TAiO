using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Model
{
    public class Pentomino: PredefinedPieces
    {
        public Pentomino()
        {
            UniquePieces = new List<Piece>();
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(4, 0)})); //1
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(0, 2), new Point(1, 0), new Point(1, 1), new Point(2, 1)})); //2
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 2), new Point(2, 1)})); //3
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(3, 0), new Point(3, 1)})); //4
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(3, 1)})); //5
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(2, 1)})); //6
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(2, 0)})); //7
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(1, 1), new Point(2, 0), new Point(2, 1), new Point(3, 0)})); //8
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(2, 1), new Point(3, 1)})); //9
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(0, 2), new Point(1, 1), new Point(2, 1)})); //10
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 2), new Point(1, 0), new Point(1, 1), new Point(1, 2)})); //11
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 2), new Point(1, 2), new Point(2, 0), new Point(2, 1), new Point(2, 2)})); //12
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 2), new Point(1, 1), new Point(1, 2), new Point(2, 0), new Point(2, 1)})); //13
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(2, 1)})); //14
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(2, 1), new Point(3, 1)})); //15
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(1, 1)})); //16
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(0, 2), new Point(1, 1), new Point(2, 0), new Point(2, 1)})); //17
            UniquePieces.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(2, 2)})); //18
        }
        public override List<Piece> GeneratePieces(List<int> n_list)
        {
            if (n_list.Count > 18)
                return null;
            var generated_pieces = new List<Piece>();
            for (int n = 0; n < n_list.Count; n++)
            {
                for (int i = 0; i < n_list[n]; i++)
                    generated_pieces.Add(UniquePieces[n].DeepCopy());
            }
            return generated_pieces;
        }
        public override Dictionary<Piece, int> GeneratePredefinedPieces(List<int> n_list)
        {
            if (n_list.Count > 18)
                return null;
            var generated_pieces = new Dictionary<Piece, int>();
            for (int i = 0; i < n_list.Count; i++)
            {
                generated_pieces.Add(UniquePieces[i].DeepCopy(), n_list[i]);
            }

            for (int i = n_list.Count; i < UniquePieces.Count; i++)
            {
                generated_pieces.Add(UniquePieces[i].DeepCopy(), 0);
            }

            return generated_pieces;
        }
    }
}
