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
            var i = 0;
            Assert.Throws<IndexOutOfRangeException>(() => arr[maxArrLength]);
            // Indexer is read only
            //arr[0] = default(int);

            Assert.True(arr.Count == 0);
            Assert.True(-1 == arr.Delete(5));
            Assert.True(-1 == arr.Delete(0));
            Assert.True(arr.Count == 0);
            Assert.True(arr.Count == 0);

            for(i = 0; i < fixture.unsortedArray.Length; i++)
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
            foreach(var item in arr)
            {
                Assert.True(item == fixture.sortedArray[i++]);
            }

            // Array is full.
            Assert.Throws<InvalidOperationException>(() => arr.Insert(99));

            for(i = 0; i < fixture.sortedArray.Length; i++)
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
            for(i = fixture.sortedArray.Length - 1; i >= 0 ; i--)
            {
                Assert.True(arr.Count == i + 1);
                Assert.True(i == arr.Delete(fixture.sortedArray[i]));
                Assert.True(arr.Count == i);
            }

            Assert.True(arr.Count == 0);
            Assert.True(arr.Length == maxArrLength);
        }
    }
}
