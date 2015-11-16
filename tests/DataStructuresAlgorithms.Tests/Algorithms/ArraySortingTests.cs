using Xunit;
using DataStructuresAlgorithms.Algorithms;
using System;

namespace DataStructuresAlgorithms.Tests.Algorithms
{
    public class SortedIntArraysFixture
    {
        public int[][] intSorted;

        public SortedIntArraysFixture()
        {
            var sortedBig = new int[]
                { 000, 111, 222, 333, 444, 555, 666,777, 888, 999 };
            var sortedTwo = new int[] { 222, 888 };
            var sortedOne = new int[] { 999 };
            var sortedThree = new int[] { 000, 333, 999 };
            var sortedFour = new int[] { 111, 444, 555, 666 };
            var sortedEmpty = new int[] { };
            intSorted = new int[][] { sortedOne, sortedTwo, sortedThree,
                sortedFour, sortedBig, sortedEmpty};
        }
    }

    public abstract class IntArraySortingTests
    {
        protected int[][] intSorted, intUnsorted;
        protected SortedIntArraysFixture sortedArrays;
        protected Action<int[]> ArraySortingAlgorithm;

        public IntArraySortingTests()
        {
            var unsortedBig =
                new int[] { 888, 222, 333, 000, 999, 777, 555, 111, 666, 444 };
            var unsortedTwo = new int[] { 888, 222 };
            var unsortedOne = new int[] { 999 };
            var unsortedThree = new int[] { 333, 000, 999 };
            var unsortedFour = new int[] { 555, 111, 666, 444 };
            var unsortedEmpty = new int[] { };

            // The order matches sortedArrays.intSorted
            intUnsorted = new int[][] { unsortedOne, unsortedTwo,
                unsortedThree, unsortedFour, unsortedBig, unsortedEmpty };
        }

        [Fact]
        public void IntArraySortingTest0()
        {
            var i = 0;
            foreach (var unsortedArr in intUnsorted)
            {
                var j = 0;
                ArraySortingAlgorithm(unsortedArr);
                foreach (var value in unsortedArr)
                {
                    Assert.True(value == sortedArrays.intSorted[i][j++]);
                }
                i++;
            }
        }
    }

    public class BubbleSortTests :
        IntArraySortingTests, IClassFixture<SortedIntArraysFixture>
    {
        public BubbleSortTests(SortedIntArraysFixture fixture)
        {
            sortedArrays = fixture;
            ArraySortingAlgorithm = ArraySorting.BubbleSort;
        }
    }

    public class SelectionSortTests :
        IntArraySortingTests, IClassFixture<SortedIntArraysFixture>
    {
        public SelectionSortTests(SortedIntArraysFixture fixture)
        {
            sortedArrays = fixture;
            ArraySortingAlgorithm = ArraySorting.SelectionSort;
        }
    }

    public class InsertionSortTests :
        IntArraySortingTests, IClassFixture<SortedIntArraysFixture>
    {
        public InsertionSortTests(SortedIntArraysFixture fixture)
        {
            sortedArrays = fixture;
            ArraySortingAlgorithm = ArraySorting.InsertionSort;
        }
    }
}
