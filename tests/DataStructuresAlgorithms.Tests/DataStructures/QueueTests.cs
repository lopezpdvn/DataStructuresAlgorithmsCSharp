using System;
using Xunit;
using DataStructuresAlgorithms.AbstractDataTypes;

namespace DataStructuresAlgorithms.Tests.DataStructures
{
    public abstract class QueueTests
    {
        protected abstract IQueue<T> GetQueueImplementation<T>();

        [Fact]
        public void QueueGeneralTest0()
        {
            IQueue<int> queue = GetQueueImplementation<int>();
            var fixture = new { TestArray0 = new int[] { 3, 6, 9, 12 } };
            Assert.True(queue.IsEmpty);
            Assert.True(queue.Count == 0);
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
            Assert.Throws<InvalidOperationException>(() => queue.Peek());

            for (var i = 0; i < fixture.TestArray0.Length; i++)
            {
                Assert.True(queue.Count == i);
                queue.Enqueue(fixture.TestArray0[i]);
                Assert.False(queue.IsEmpty);
                Assert.True(queue.Peek() == fixture.TestArray0[0]);
            }

            for (var i = 0; i < fixture.TestArray0.Length; i++)
            {
                Assert.False(queue.IsEmpty);
                Assert.True(queue.Count == fixture.TestArray0.Length - i);
                Assert.True(fixture.TestArray0[i] == queue.Peek());
                Assert.True(fixture.TestArray0[i] == queue.Dequeue());
            }

            Assert.True(queue.IsEmpty);
            Assert.True(queue.Count == 0);
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }
    }

    public class QueueSinglyLinkedListTests : QueueTests
    {
        protected override IQueue<T> GetQueueImplementation<T>()
        {
            return new QueueSinglyLinkedList<T>();
        }
    }

    public class CircularArrayQueueTests : QueueTests
    {
        protected override IQueue<T> GetQueueImplementation<T>()
        {
            // Instantiate a big enough array.
            return new CircularArrayQueue<T>(99);
        }

        [Fact]
        public void FullQueueAndWrapAroundTest()
        {
            var maxSize = 5;
            var queue = new CircularArrayQueue<int>(maxSize);

            for(var j = 0; j < 2; j++)
            {
                Assert.True(queue.IsEmpty);
                Assert.False(queue.IsFull);
                Assert.True(queue.Count == 0);
                Assert.True(queue.Length == maxSize);
                Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
                Assert.Throws<InvalidOperationException>(() => queue.Peek());

                for (var i = 0; i < maxSize; i++)
                {
                    Assert.False(queue.IsFull);
                    queue.Enqueue(i * 2);
                    Assert.True(queue.Peek() == 0);
                    Assert.False(queue.IsEmpty);
                    Assert.True(queue.Count == i + 1);
                }

                Assert.True(queue.IsFull);
                Assert.Throws<InvalidOperationException>(() => queue.Enqueue(1));

                for (var i = 0; i < maxSize; i++)
                {
                    Assert.True(queue.Count == maxSize - i);
                    Assert.False(queue.IsEmpty);
                    Assert.True(queue.Peek() == i * 2);
                    Assert.True(queue.Dequeue() == i * 2);
                    Assert.True(queue.Count == maxSize - i - 1);
                    Assert.False(queue.IsFull);
                }

                Assert.True(queue.IsEmpty);
                Assert.False(queue.IsFull);
            }
        }
    }
}
