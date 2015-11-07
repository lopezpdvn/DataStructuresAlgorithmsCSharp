using Xunit;
using DataStructuresAlgorithms.Algorithms;

namespace DataStructuresAlgorithms.Tests.Algorithms
{
    public class SortedArraysFixture
    {
        public int[][] intSorted;

        public SortedArraysFixture()
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

    public class ArraySortingTests : IClassFixture<SortedArraysFixture>
    {
        int[][] intUnsorted;
        SortedArraysFixture sortedArrays;

        public ArraySortingTests(SortedArraysFixture fixture)
        {
            sortedArrays = fixture;
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
        public void BubbleSortTestInts0()
        {
            var i = 0;
            foreach(var unsortedArr in intUnsorted)
            {
                var j = 0;
                ArraySorting.BubbleSort(unsortedArr);
                foreach(var value in unsortedArr)
                {
                    Assert.True(value == sortedArrays.intSorted[i][j++]);
                }
                i++;
            }
        }

        [Fact]
        public void SelectionSortTestInts0()
        {
            var i = 0;
            foreach (var unsortedArr in intUnsorted)
            {
                var j = 0;
                ArraySorting.SelectionSort(unsortedArr);
                foreach (var value in unsortedArr)
                {
                    Assert.True(value == sortedArrays.intSorted[i][j++]);
                }
                i++;
            }
        }

        [Fact]
        public void InsertionSortTestInts0()
        {
            var i = 0;
            foreach (var unsortedArr in intUnsorted)
            {
                var j = 0;
                ArraySorting.InsertionSort(unsortedArr);
                foreach (var value in unsortedArr)
                {
                    Assert.True(value == sortedArrays.intSorted[i][j++]);
                }
                i++;
            }
        }
    }
}
