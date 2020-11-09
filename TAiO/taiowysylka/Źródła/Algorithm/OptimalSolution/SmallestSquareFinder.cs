using System.Collections.Generic;
using Algorithm.Model;

namespace TAiO
{
    public abstract class SmallestSquareFinder
    {
        protected Board Board { get; set; }
        public abstract List<Solution> CalculateSolutions();
    }
}