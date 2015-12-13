using System;
using Xunit;
using DataStructuresAlgorithms.DataStructures.Array;

namespace DataStructuresAlgorithms.Tests.DataStructures
{
    public class SortedArrayTests
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
            Assert.Throws<IndexOutOfRangeException>(() => arr[maxArrLength]);
            // Indexer is read only
            //arr[0] = default(int);

            Assert.True(arr.Count == 0);
            Assert.False(arr.Delete(5));
            Assert.False(arr.Delete(0));
            Assert.True(arr.Count == 0);
            Assert.True(arr.Count == 0);

            for(var i = 0; i < fixture.unsortedArray.Length; i++)
            {
                arr.Insert(fixture.unsortedArray[i]);
                Assert.True(arr.Count == i + 1);
            }

            for(var i = 0; i < fixture.sortedArray.Length; i++)
            {
                Assert.True(arr[i] == fixture.sortedArray[i]);
            }

            // Array is full.
            Assert.Throws<InvalidOperationException>(() => arr.Insert(99));

            for(var i = 0; i < fixture.sortedArray.Length; i++)
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
            for(var i = 0; i < fixture.sortedArray.Length; i++)
            {
                Assert.True(arr.Delete(fixture.sortedArray[i]));
                Assert.True(arr.Count == maxArrLength - i - 1);
            }

            Assert.True(arr.Count == 0);
            Assert.True(arr.Length == maxArrLength);
        }
    }
}
