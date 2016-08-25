using System;
using System.Linq;
using Xunit;
using DataStructuresAlgorithms.DataStructures.Array;

namespace DataStructuresAlgorithms.Tests.DataStructures.Array
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

    [CollectionDefinition("Int Array Sorting Collection")]
    public class IntArraySortingCollection :
        ICollectionFixture<SortedIntArraysFixture> { }

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

    [Collection("Int Array Sorting Collection")]
    public class BubbleSortTests : IntArraySortingTests
    {
        public BubbleSortTests(SortedIntArraysFixture fixture)
        {
            sortedArrays = fixture;
            ArraySortingAlgorithm = SortedArrayInt.BubbleSort;
        }
    }

    [Collection("Int Array Sorting Collection")]
    public class SelectionSortTests : IntArraySortingTests
    {
        public SelectionSortTests(SortedIntArraysFixture fixture)
        {
            sortedArrays = fixture;
            ArraySortingAlgorithm = SortedArrayInt.SelectionSort;
        }
    }

    [Collection("Int Array Sorting Collection")]
    public class InsertionSortTests : IntArraySortingTests
    {
        public InsertionSortTests(SortedIntArraysFixture fixture)
        {
            sortedArrays = fixture;
            ArraySortingAlgorithm = SortedArrayInt.InsertionSort;
        }
    }

    /*
    [Collection("Int Array Sorting Collection")]
    public class QuickSortSortTests : IntArraySortingTests
    {
        public QuickSortSortTests(SortedIntArraysFixture fixture)
        {
            sortedArrays = fixture;
            ArraySortingAlgorithm = SortedArrayInt.QuickSort;
        }
    }
    */

    [Collection("Int Array Sorting Collection")]
    public class MergeSortTests : IntArraySortingTests
    {
        public MergeSortTests(SortedIntArraysFixture fixture)
        {
            sortedArrays = fixture;
            ArraySortingAlgorithm = SortedArrayInt.MergeSort;
        }

        [Fact]
        public void MergeTest0()
        {
            int[] arrA = { 23, 47, 81, 95 },
                arrB = { 7, 14, 39, 55, 62, 74 },
                arrCAnswer = { 7, 14, 23, 39, 47, 55, 62, 74, 81, 95 },
                arrC = new int[arrA.Length + arrB.Length];

            SortedArrayInt.Merge(arrA, arrA.Length, arrB, arrB.Length, arrC);
            Assert.True(arrC.SequenceEqual(arrCAnswer));
        }
    }

    public class SortedArrayIntTests
    {
        [Fact]
        public void SortedArrayTest0()
        {
            var fixture = new
            {
                unsortedArray = new int[]
                    { 888, 222, 333, 000, 999, 777, 555, 111, 666, 444 },
                sortedArray = new int[]
                    { 000, 111, 222, 333, 444, 555, 666, 777, 888, 999 }
            };
            var maxArrLength = fixture.sortedArray.Length;
            var arr = new SortedArrayInt(maxArrLength);
            var i = 0;
            Assert.Throws<IndexOutOfRangeException>(() => arr[maxArrLength]);
            // Indexer is read only
            //arr[0] = default(int);

            Assert.True(arr.Count == 0);
            Assert.True(-1 == arr.Delete(5));
            Assert.True(-1 == arr.Delete(0));
            Assert.True(arr.Count == 0);
            Assert.True(arr.Count == 0);

            for (i = 0; i < fixture.unsortedArray.Length; i++)
            {
                arr.Insert(fixture.unsortedArray[i]);
                var j = 0;
                foreach (var item in arr)
                {
                    j++;
                }
                Assert.True(j == i + 1);
                Assert.True(arr.Count == i + 1);
            }

            i = 0;
            foreach (var item in arr)
            {
                Assert.True(item == fixture.sortedArray[i++]);
            }

            // Array is full.
            Assert.Throws<InvalidOperationException>(() => arr.Insert(99));

            for (i = 0; i < fixture.sortedArray.Length; i++)
            {
                Assert.True(
                    arr.BinarySearchIterative(fixture.sortedArray[i]) == i);
                Assert.True(
                    arr.BinarySearchRecursive(fixture.sortedArray[i]) == i);
            }

            // Search non existent
            Assert.True(arr.BinarySearchIterative(-99999) == -1);
            Assert.True(arr.BinarySearchRecursive(-88888) == -1);

            // Delete all
            for (i = 0; i < fixture.unsortedArray.Length; i++)
            {
                Assert.True(arr.Count == maxArrLength - i);
                Assert.True(arr.BinarySearchRecursive(fixture.unsortedArray[i])
                    == arr.Delete(fixture.unsortedArray[i]));
                Assert.True(arr.Count == maxArrLength - i - 1);
            }

            Assert.True(arr.Count == 0);
            Assert.True(arr.Length == maxArrLength);
        }
    }
}
