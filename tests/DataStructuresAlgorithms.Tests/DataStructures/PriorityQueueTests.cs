using System;
using Xunit;
using DataStructuresAlgorithms.AbstractDataTypes;

namespace DataStructuresAlgorithms.Tests.DataStructures
{
    public class PriorityQueueIntArrayTests
    {
        [Fact]
        public void PriorityQueueGeneralTest0()
        {
            IPriorityQueue<int> pqueue = new PriorityQueueIntSortedArray();
            var fixture = new { TestArray0 = new int[] { 9, 6, 3, 15, 12, 0, 18 },
                TestSortedArray0 = new int[] { 18, 15, 12, 9, 6, 3, 0 }
            };
            Assert.True(pqueue.IsEmpty);
            Assert.True(pqueue.Count == 0);
            Assert.Throws<InvalidOperationException>(() => pqueue.Dequeue());
            Assert.Throws<InvalidOperationException>(() => pqueue.Peek());

            for (var i = 0; i < fixture.TestArray0.Length; i++)
            {
                Assert.True(pqueue.Count == i);
                pqueue.Enqueue(fixture.TestArray0[i]);
                Assert.False(pqueue.IsEmpty);
            }

            for (var i = 0; i < fixture.TestArray0.Length; i++)
            {
                Assert.False(pqueue.IsEmpty);
                Assert.True(pqueue.Count == fixture.TestArray0.Length - i);
                Assert.True(fixture.TestSortedArray0[i] == pqueue.Peek());
                Assert.True(fixture.TestSortedArray0[i] == pqueue.Dequeue());
            }

            Assert.True(pqueue.IsEmpty);
            Assert.True(pqueue.Count == 0);
            Assert.Throws<InvalidOperationException>(() => pqueue.Dequeue());
            Assert.Throws<InvalidOperationException>(() => pqueue.Peek());
        }

        [Fact]
        public void FullPriorityQueueTest()
        {
            var length = 5;
            var pqueue = new PriorityQueueIntSortedArray(length);

            for(var j = 0; j < 2; j++)
            {
                Assert.True(pqueue.IsEmpty);
                Assert.False(pqueue.IsFull);
                Assert.True(pqueue.Count == 0);
                Assert.True(pqueue.Length == length);
                Assert.Throws<InvalidOperationException>(() => pqueue.Dequeue());
                Assert.Throws<InvalidOperationException>(() => pqueue.Peek());

                for (var i = 0; i < length; i++)
                {
                    Assert.False(pqueue.IsFull);
                    pqueue.Enqueue(i * 2);
                    Assert.True(pqueue.Peek() == i * 2);
                    Assert.False(pqueue.IsEmpty);
                    Assert.True(pqueue.Count == i + 1);
                }

                Assert.True(pqueue.IsFull);
                Assert.Throws<InvalidOperationException>(() => pqueue.Enqueue(1));

                for (var i = 0; i < length; i++)
                {
                    Assert.True(pqueue.Count == length - i);
                    Assert.False(pqueue.IsEmpty);
                    Assert.True((pqueue.Count - 1) * 2 == pqueue.Peek());
                    Assert.True((pqueue.Count - 1) * 2 == pqueue.Dequeue());
                    Assert.True(pqueue.Count == length - i - 1);
                    Assert.False(pqueue.IsFull);
                }

                Assert.True(pqueue.IsEmpty);
                Assert.False(pqueue.IsFull);
            }
        }
    }
}
