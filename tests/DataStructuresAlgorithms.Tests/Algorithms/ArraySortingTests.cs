using Xunit;
using System;
using DataStructuresAlgorithms.Algorithms;

namespace DataStructuresAlgorithms.Tests.Algorithms
{
    public class ArraySortingTests
    {
        int[] unsortedBig, sortedBig, unsortedTwo, sortedTwo, unsortedOne,
            sortedOne, unsortedThree, sortedThree, unsortedFour, sortedFour,
            unsortedEmpty, sortedEmpty;
        int[][] intSorted, intUnsorted;

        public ArraySortingTests()
        {
            unsortedBig = new int[] { 888, 222, 333, 000, 999, 777, 555, 111, 666, 444 };
            sortedBig = new int[] { 000, 111, 222, 333, 444, 555, 666, 777, 888, 999 };
            unsortedTwo = new int[] { 888, 222 };
            sortedTwo = new int[] { 222, 888 };
            unsortedOne = new int[] { 999 };
            sortedOne = new int[] { 999 };
            unsortedThree = new int[] { 333, 000, 999 };
            sortedThree = new int[] { 000, 333, 999 };
            unsortedFour = new int[] { 555, 111, 666, 444 };
            sortedFour = new int[] {111, 444, 555, 666};
            unsortedEmpty = new int[] { };
            sortedEmpty = new int[] { };
            intSorted = new int[][] { sortedOne, sortedTwo, sortedThree,
                sortedFour, sortedBig, sortedEmpty};
            intUnsorted = new int[][] { unsortedOne, unsortedTwo, unsortedThree,
                unsortedFour, unsortedBig, unsortedEmpty };
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
                    Assert.True(value == intSorted[i][j++]);
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
                    Assert.True(value == intSorted[i][j++]);
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
                    Assert.True(value == intSorted[i][j++]);
                }
                i++;
            }
        }
    }
}
