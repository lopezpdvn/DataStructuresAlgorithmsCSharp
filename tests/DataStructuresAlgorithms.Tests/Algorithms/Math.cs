using System;
using Xunit;
using MathAlgs = DataStructuresAlgorithms.Algorithms;

namespace DataStructuresAlgorithms.Tests.Algorithms.Math
{
    public class MathTestsFixture
    {
        public readonly int[] TriangularNumbers = { 0, 1, 3, 6, 10, 15, 21,
            28, 36, 45, 55, 66, 78, 91, 105, 120, 136, 153, 171, 190, 210,
            231, 253, 276, 300, 325, 351, 378, 406 };
        public readonly int[] Factorials = { 1, 1, 2, 6, 24, 120, 720, 5040,
            40320, 362880, 3628800, 39916800 };
    }

    public abstract class MathTests
    {
        protected MathTestsFixture fixture;
        protected Func<int, int> TriangularFunc, FactorialFunc;

        [Fact]
        public void TriangleTest0()
        {
            var i = 0;
            foreach(var triangularNumber in fixture.TriangularNumbers)
            {
                Assert.True(triangularNumber == TriangularFunc(i++));
            }
        }

        [Fact]
        public void FactorialTest0()
        {
            var i = 0;
            foreach(var iFactorial in fixture.Factorials)
            {
                Assert.True(iFactorial == FactorialFunc(i++));
            }
        }
    }

    [CollectionDefinition("Math Tests Collection")]
    public class MathTestsCollection : ICollectionFixture<MathTestsFixture> { }

    [Collection("Math Tests Collection")]
    public class MathTestsIterative : MathTests
    {
        public MathTestsIterative(MathTestsFixture fixture)
        {
            this.fixture = fixture;
            TriangularFunc = MathAlgs.Math.TriangularIterative;
            FactorialFunc = MathAlgs.Math.FactorialIterative;
        }
    }

    [Collection("Math Tests Collection")]
    public class MathTestsRecursive : MathTests
    {
        public MathTestsRecursive(MathTestsFixture fixture)
        {
            this.fixture = fixture;
            TriangularFunc = MathAlgs.Math.TriangularRecursive;
            FactorialFunc = MathAlgs.Math.FactorialRecursive;
        }
    }
}