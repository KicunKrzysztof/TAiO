using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Model
{
    abstract public class PredefinedPieces
    {
        public abstract List<Piece> GeneratePieces(List<int> n_list);
    }
}
