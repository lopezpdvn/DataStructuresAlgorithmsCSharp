using System;
using Xunit;
using DataStructuresAlgorithms.DataStructures.Graph;
using MathAlgs = DataStructuresAlgorithms.Algorithms;

namespace DataStructuresAlgorithms.Tests.Algorithms.Math
{
    public class MathTestsFixture
    {
        public readonly int[] TriangularNumbers = { 0, 1, 3, 6, 10, 15, 21,
            28, 36, 45, 55, 66, 78, 91, 105, 120, 136, 153, 171, 190, 210,
            231, 253, 276, 300, 325, 351, 378, 406 };
    }

    public abstract class MathTests
    {
        protected MathTestsFixture fixture;
        protected Func<int, int> IntFunc;
        protected string traversalType;
        protected DirectedGraphAdjacencyList<char> graph;

        [Fact]
        public void TriangleTest0()
        {
            var i = 0;
            foreach(var triangularNumber in fixture.TriangularNumbers)
            {
                Assert.True(triangularNumber == IntFunc(i++));
            }
        }
    }

    [CollectionDefinition("Math Tests Collection")]
    public class MathTestsCollection : ICollectionFixture<MathTestsFixture> { }

    [Collection("Math Tests Collection")]
    public class TriangularNumbersIterative : MathTests
    {
        public TriangularNumbersIterative(MathTestsFixture fixture)
        {
            this.fixture = fixture;
            IntFunc = MathAlgs.Math.TriangularIterative;
        }
    }

    [Collection("Math Tests Collection")]
    public class TriangularNumbersRecursive : MathTests
    {
        public TriangularNumbersRecursive(MathTestsFixture fixture)
        {
            this.fixture = fixture;
            IntFunc = MathAlgs.Math.TriangularRecursive;
        }
    }
}