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
            Queue<int> Queue = GetQueueImplementation<int>();
            var fixture = new { TestArray0 = new int[] { 3, 6, 9, 12 } };
            Assert.True(Queue.IsEmpty);
            Assert.True(Queue.Length == 0);
            Assert.Throws<InvalidOperationException>(() => Queue.Dequeue());
            Assert.Throws<InvalidOperationException>(() => Queue.Peek());

            for (var i = 0; i < fixture.TestArray0.Length; i++)
            {
                Assert.True(Queue.Length == i);
                Queue.Enqueue(fixture.TestArray0[i]);
                Assert.False(Queue.IsEmpty);
                Assert.True(Queue.Peek() == fixture.TestArray0[0]);
            }

            for (var i = 0; i < fixture.TestArray0.Length; i++)
            {
                Assert.False(Queue.IsEmpty);
                Assert.True(Queue.Length == fixture.TestArray0.Length - i);
                Assert.True(fixture.TestArray0[i] == Queue.Peek());
                Assert.True(fixture.TestArray0[i] == Queue.Dequeue());
            }

            Assert.True(Queue.IsEmpty);
            Assert.True(Queue.Length == 0);
            Assert.Throws<InvalidOperationException>(() => Queue.Dequeue());
            Assert.Throws<InvalidOperationException>(() => Queue.Peek());
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
