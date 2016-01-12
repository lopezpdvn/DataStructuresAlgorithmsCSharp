using System;
using System.Collections.Generic;

namespace DataStructuresAlgorithms.Algorithms
{
    public static class Misc
    {
        public static IEnumerable<int[]> TowersOfHanoiRecursiveSolver(
            int n, int from, int via, int to)
        {
            if (n < 0)
            {
                throw new InvalidOperationException("Invalid number of disks");
            }
            foreach(var step in
                _TowersOfHanoiRecursiveSolver(n, from, via, to))
            {
                yield return step;
            }
        }

        private static IEnumerable<int[]> _TowersOfHanoiRecursiveSolver(
            int n, int from, int via, int to)
        {
            if(n == 1)
            {
                yield return new int[] { 0, from, to };
            }
            else
            {
                foreach(var step in
                    _TowersOfHanoiRecursiveSolver(n - 1, from, to, via))
                {
                    yield return step;
                }

                // Identifier of disk is zero based: Disk 1 is `0`,
                // Disk 2 is `1`, etc.
                yield return new int[] { n - 1, from, to };

                foreach (var step in
                    _TowersOfHanoiRecursiveSolver(n - 1, via, from, to))
                {
                    yield return step;
                }
            }
        }
    }
}
