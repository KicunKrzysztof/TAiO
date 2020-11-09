using System.Collections.Generic;
using System.Linq;
using TAiO;

namespace Algorithm
{
    public class SolutionComparer
    {
        public bool AreEqual(int[,] solutionA, int[,] solutionB)
        {
            if (solutionA.GetLength(0) != solutionB.GetLength(0) || solutionA.GetLength(1) != solutionB.GetLength(1))
                return false;

            Dictionary<int, int> pieceMappingA = new Dictionary<int, int>();
            Dictionary<int, int> pieceMappingB = new Dictionary<int, int>();

            int aPiecesCount = 1;
            int bPiecesCount = 1;


            for (int i = 0; i < solutionA.GetLength(0); i++)
            {
                for (int j = 0; j < solutionA.GetLength(1); j++)
                {
                    var valueA = solutionA[i, j];
                    var valueB = solutionB[i, j];

                    if ((valueA != 0 && valueB == 0) || (valueA == 0 && valueB != 0))
                    {
                        return false;
                    }

                    if (valueA != 0)
                    {
                        if (!pieceMappingA.ContainsKey(valueA))
                        {
                            pieceMappingA.Add(valueA, -1 * aPiecesCount);
                        }
                        if (!pieceMappingB.ContainsKey(valueB))
                        {
                            pieceMappingB.Add(valueB, -1 * bPiecesCount);
                        }

                        if (pieceMappingA[valueA] != pieceMappingB[valueB])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public static bool AreEqual(List<SolutionRow> solutionA, List<SolutionRow> solutionB)
        {
            if (solutionA.Count != solutionB.Count)
                return false;

            return solutionA.All(solutionB.Contains);
        }
    }
}
