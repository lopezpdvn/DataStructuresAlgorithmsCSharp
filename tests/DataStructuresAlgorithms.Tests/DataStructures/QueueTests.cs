using System;
using Xunit;
using DataStructuresAlgorithms.AbstractDataTypes;

namespace DataStructuresAlgorithms.Tests.DataStructures
{
    public abstract class QueueTests
    {
        protected abstract Queue<T> GetQueueImplementation<T>();

        [Fact]
        public void QueueGeneralTest0()
        {
            Queue<int> queue = GetQueueImplementation<int>();
            var fixture = new { TestArray0 = new int[] { 3, 6, 9, 12 } };
            Assert.True(queue.IsEmpty);
            Assert.True(queue.Length == 0);
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
            Assert.Throws<InvalidOperationException>(() => queue.Peek());

            for (var i = 0; i < fixture.TestArray0.Length; i++)
            {
                Assert.True(queue.Length == i);
                queue.Enqueue(fixture.TestArray0[i]);
                Assert.False(queue.IsEmpty);
                Assert.True(queue.Peek() == fixture.TestArray0[0]);
            }

            for (var i = 0; i < fixture.TestArray0.Length; i++)
            {
                Assert.False(queue.IsEmpty);
                Assert.True(queue.Length == fixture.TestArray0.Length - i);
                Assert.True(fixture.TestArray0[i] == queue.Peek());
                Assert.True(fixture.TestArray0[i] == queue.Dequeue());
            }

            Assert.True(queue.IsEmpty);
            Assert.True(queue.Length == 0);
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }
    }

    public class QueueSinglyLinkedListTests : QueueTests
    {
        protected override Queue<T> GetQueueImplementation<T>()
        {
            return new QueueSinglyLinkedList<T>();
        }
    }
}
