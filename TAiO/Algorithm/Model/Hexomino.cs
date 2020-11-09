using System.Collections.Generic;

namespace Algorithm.Model
{
    public class Hexomino : PredefinedPieces
    {
        private List<Piece> hexominos;
        public Hexomino()
        {
            hexominos = new List<Piece>();
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(4, 0), new Point(5, 0) })); //1
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(4, 0) })); //2
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(1, 0), new Point(1, 1), new Point(2, 0), new Point(3, 0), new Point(4, 0) })); //3
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(2, 1), new Point(3, 0), new Point(4, 0) })); //4
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(2, 0), new Point(3, 0), new Point(4, 0) })); //5
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(2, 0), new Point(3, 0) })); //6
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(2, 0), new Point(2, 1), new Point(3, 0) })); //7

            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(3, 1) })); //8
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(1, 0), new Point(1, 1), new Point(2, 0), new Point(2, 1), new Point(3, 0) })); //9
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(0, 2), new Point(1, 0), new Point(2, 0), new Point(3, 0) })); //10
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(2, 0), new Point(3, 0) })); //11
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(0, 2), new Point(1, 1), new Point(2, 1), new Point(3, 1) })); //12
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(0, 2), new Point(1, 0), new Point(1, 1), new Point(2, 1), new Point(3, 1) })); //13
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(0, 2), new Point(1, 1), new Point(2, 0), new Point(2, 1), new Point(3, 1) })); //14

            hexominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(0, 2), new Point(1, 1), new Point(2, 1), new Point(3, 0), new Point(3, 1) })); //15
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(1, 1), new Point(1, 2), new Point(2, 0), new Point(2, 1), new Point(3, 1) })); //16
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(2, 1), new Point(3, 1) })); //17
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(2, 0), new Point(3, 0) })); //18
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(2, 0), new Point(3, 0), new Point(3, 1) })); //19
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(1, 1), new Point(2, 0), new Point(2, 1), new Point(3, 0), new Point(4, 0) })); //20
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(2, 0), new Point(2, 1), new Point(3, 0) })); //21

            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(2, 0), new Point(2, 1) })); //22
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 2), new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(2, 1), new Point(3, 1) })); //23
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(0, 2), new Point(1, 1), new Point(1, 2), new Point(2, 1) })); //24
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 2), new Point(1, 1), new Point(1, 2), new Point(2, 0), new Point(2, 1), new Point(3, 1) })); //25
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 2), new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(2, 0), new Point(3, 0) })); //26
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(0, 2), new Point(1, 0), new Point(1, 1), new Point(2, 0), new Point(3, 0) })); //27
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(0, 2), new Point(1, 0), new Point(1, 2), new Point(2, 0) })); //28

            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 2), new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(2, 0) })); //29
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(0, 2), new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(2, 1) })); //30
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(0, 2), new Point(1, 1), new Point(2, 0), new Point(2, 1), new Point(3, 0) })); //31
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 0), new Point(1, 0), new Point(1, 1), new Point(2, 0), new Point(2, 1), new Point(2, 2) })); //32
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(2, 0), new Point(2, 1) })); //33
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 2), new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(2, 0), new Point(2, 1) })); //34
            hexominos.Add(new Piece(new List<Point>() { new Point(0, 2), new Point(1, 1), new Point(1, 2), new Point(2, 0), new Point(2, 1), new Point(3, 0) })); //35
        }   
        public override List<Piece> GeneratePieces(List<int> n_list)
        {
            if (n_list.Count > 35)
                return null;
            var generated_pieces = new List<Piece>();
            for (int n = 0; n < n_list.Count; n++)
            {
                for (int i = 0; i < n_list[n]; i++)
                    generated_pieces.Add(hexominos[n].DeepCopy());
            }
            return generated_pieces;
        }
        public override Dictionary<Piece, int> GeneratePredefinedPieces(List<int> n_list)
        {
            if (n_list.Count > 35)
                return null;
            var generated_pieces = new Dictionary<Piece, int>();
            for (int i = 0; i < n_list.Count; i++)
            {
                generated_pieces.Add(hexominos[i].DeepCopy(), n_list[i]);
            }

            for (int i = n_list.Count; i < hexominos.Count; i++)
            {
                generated_pieces.Add(hexominos[i].DeepCopy(),0);
            }
            
            return generated_pieces;
        }
    }
}
