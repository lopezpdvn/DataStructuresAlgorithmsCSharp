using System;
using System.Linq;
using Xunit;
using Algs = DataStructuresAlgorithms.Algorithms;

namespace DataStructuresAlgorithms.Tests.Algorithms.Misc
{
    public class MiscTestsFixture
    {
        public readonly int[][][] TowersOfHanoiSolutions = {
            new[]
            {
                new[] { 0, 0, 2 }
            },
            new[]
            {
                new[] { 0, 0, 1 },
                new[] { 1, 0, 2 },
                new[] { 0, 1, 2 }
            },
            new[]
            {
                new[] { 0, 0, 2 },
                new[] { 1, 0, 1 },
                new[] { 0, 2, 1 },
                new[] { 2, 0, 2 },
                new[] { 0, 1, 0 },
                new[] { 1, 1, 2 },
                new[] { 0, 0, 2 }
            }
        };
    }

    public abstract class MiscTests
    {
        protected MiscTestsFixture fixture;
        protected Func<int, int, int, int, int[]> TowersOfHanoiSolver;

        [Fact]
        public void TowersOfHanoiSolverTest()
        {
            for(var i = 0; i < fixture.TowersOfHanoiSolutions.Length; i++)
            {
                foreach(var sol in fixture.TowersOfHanoiSolutions[i])
                {
                    Assert.True(sol.SequenceEqual(
                        TowersOfHanoiSolver(i + 1, 0, 1, 2)));
                }
            }
        }
    }

    [CollectionDefinition("Misc Tests Collection")]
    public class MiscTestsCollection : ICollectionFixture<MiscTestsFixture> { }

    //[Collection("Misc Tests Collection")]
    //public class MiscTestsIterative : MiscTests
    //{
    //    public MiscTestsIterative(MiscTestsFixture fixture)
    //    {
    //        this.fixture = fixture;
    //        TriangularFunc = MathAlgs.Math.TriangularIterative;
    //        FactorialFunc = MathAlgs.Math.FactorialIterative;
    //    }
    //}

    [Collection("Misc Tests Collection")]
    public class MiscTestsRecursive : MiscTests
    {
        public MiscTestsRecursive(MiscTestsFixture fixture)
        {
            this.fixture = fixture;
            TowersOfHanoiSolver = Algs.Misc.TowersOfHanoiRecursiveSolver;
        }
    }
}