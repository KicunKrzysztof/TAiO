using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Model;
using TAiO;

namespace Algorithm
{
    public class UniqueSolutionsFinder
    {
        public List<Solution> Find(List<Solution> solutions)
        {
            var uniqueSolutions = new List<Solution>();
            foreach (var solution in solutions)
            {
                var otherSolutions = solutions.Where(a => a != solution);
                bool alreadyFound = false;
                foreach (var otherSolution in otherSolutions)
                {
                    if (PieceExtensions.CompareLists(solution.solutionRows.ToList(),
                        otherSolution.solutionRows.ToList()))
                    {
                        alreadyFound = true;
                    }
                }

                if (!alreadyFound)
                {
                    uniqueSolutions.Add(solution);
                }
               
            }

            return uniqueSolutions;
        }

    }
}
