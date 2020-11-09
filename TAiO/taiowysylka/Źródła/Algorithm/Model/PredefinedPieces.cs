using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Model
{
    abstract public class PredefinedPieces
    {
        public List<Piece> UniquePieces { get; protected set; }

        public abstract List<Piece> GeneratePieces(List<int> n_list);
        public abstract Dictionary<Piece, int> GeneratePredefinedPieces(List<int> n_list);
    }
}
