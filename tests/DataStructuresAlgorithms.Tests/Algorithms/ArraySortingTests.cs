using Xunit;
using System;
using DataStructuresAlgorithms.Algorithms;

namespace DataStructures.Tests
{
    public class ArraySortingTests
    {
        int[] unorderedBig, orderedBig, unorderedTwo, orderedTwo, unorderedOne,
            orderedOne, unorderedThree, orderedThree, unorderedFour, orderedFour,
            unorderedEmpty, orderedEmpty;
        int[][] intOrdered, intUnordered;

        public void InitializeIntArrays()
        {
            unorderedBig = new int[] { 888, 222, 333, 000, 999, 777, 555, 111, 666, 444 };
            orderedBig = new int[] { 000, 111, 222, 333, 444, 555, 666, 777, 888, 999 };
            unorderedTwo = new int[] { 888, 222 };
            orderedTwo = new int[] { 222, 888 };
            unorderedOne = new int[] { 999 };
            orderedOne = new int[] { 999 };
            unorderedThree = new int[] { 333, 000, 999 };
            orderedThree = new int[] { 000, 333, 999 };
            unorderedFour = new int[] { 555, 111, 666, 444 };
            orderedFour = new int[] {111, 444, 555, 666};
            unorderedEmpty = new int[] { };
            orderedEmpty = new int[] { };
            intOrdered = new int[][] { orderedOne, orderedTwo, orderedThree,
                orderedFour, orderedBig, orderedEmpty};
            intUnordered = new int[][] { unorderedOne, unorderedTwo, unorderedThree,
                unorderedFour, unorderedBig, unorderedEmpty };
        }

        [Fact]
        public void BubbleSortTestInts0()
        {
            InitializeIntArrays();
            var i = 0;
            foreach(var unorderedArr in intUnordered)
            {
                var j = 0;
                ArraySorting.BubbleSort(unorderedArr);
                foreach(var value in unorderedArr)
                {
                    Assert.True(value == intOrdered[i][j++]);
                }
                i++;
            }
        }

        [Fact]
        public void SelectionSortTestInts0()
        {
            InitializeIntArrays();
            var i = 0;
            foreach (var unorderedArr in intUnordered)
            {
                var j = 0;
                ArraySorting.SelectionSort(unorderedArr);
                foreach (var value in unorderedArr)
                {
                    Assert.True(value == intOrdered[i][j++]);
                }
                i++;
            }
        }

        [Fact]
        public void InsertionSortTestInts0()
        {
            InitializeIntArrays();
            var i = 0;
            foreach (var unorderedArr in intUnordered)
            {
                var j = 0;
                ArraySorting.InsertionSort(unorderedArr);
                foreach (var value in unorderedArr)
                {
                    Assert.True(value == intOrdered[i][j++]);
                }
                i++;
            }
        }
    }
}
