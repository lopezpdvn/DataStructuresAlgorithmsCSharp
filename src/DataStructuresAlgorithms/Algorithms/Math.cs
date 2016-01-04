using System;

namespace DataStructuresAlgorithms.Algorithms
{
    public static class Math
    {
        public static int TriangularIterative(int n)
        {
            if(n < 0)
            {
                throw new InvalidOperationException(
                    "Argument is not natural number");
            }
            int total = 0;
            while(n >= 0)
            {
                total += n--;
            }
            return total;
        }

        public static int TriangularRecursive(int n)
        {
            if(n < 0)
            {
                throw new InvalidOperationException(
                    "Argument is not natural number");
            }
            return _TriangularRecursive(n);
        }

        private static int _TriangularRecursive(int n)
        {
            if(n <= 1)
            {
                return n;
            }
            else
            {
                return n + _TriangularRecursive(n - 1);
            }
        }

        public static int FactorialIterative(int n)
        {
            if (n < 0)
            {
                throw new InvalidOperationException(
                    "Argument is not natural number");
            }
            int total = 1;
            while (n > 0)
            {
                total *= n--;
            }
            return total;
       }

        public static int FactorialRecursive(int n)
        {
            if (n < 0)
            {
                throw new InvalidOperationException(
                    "Argument is not natural number");
            }
            return _FactorialRecursive(n);
        }

        private static int _FactorialRecursive(int n)
        {
            return n < 2 ? 1 : n *_FactorialRecursive(n - 1);
        }
    }
}
