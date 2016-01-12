using System;
using System.Linq;
using System.Collections.Generic;
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
        protected Func<int, int, int, int, IEnumerable<int[]>>
            TowersOfHanoiSolver;

        [Fact]
        public void TowersOfHanoiSolverTest()
        {
            for (var i = 0; i < fixture.TowersOfHanoiSolutions.Length; i++)
            {
                var j = 0;
                foreach (var step in TowersOfHanoiSolver(i + 1, 0, 1, 2))
                {
                    var answer = fixture.TowersOfHanoiSolutions[i][j++];
                    Assert.True(step.SequenceEqual(answer));
                }
            }
        }
    }

    [CollectionDefinition("Misc Tests Collection")]
    public class MiscTestsCollection : ICollectionFixture<MiscTestsFixture> { }

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