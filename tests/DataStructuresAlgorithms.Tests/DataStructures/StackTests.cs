using System;
using Xunit;
using DataStructuresAlgorithms.AbstractDataTypes;

namespace DataStructuresAlgorithms.Tests.DataStructures
{
    public abstract class StackTests
    {
        protected abstract IStack<T> GetStackImplementation<T>();

        [Fact]
        public void StackGeneralTest0()
        {
            IStack<int> stack = GetStackImplementation<int>();
            var fixture = new { TestArray0 = new int[] { 3, 6, 9, 12 } };
            Assert.True(stack.IsEmpty);
            Assert.True(stack.Count == 0);
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
            Assert.Throws<InvalidOperationException>(() => stack.Peek());

            for (var i = 0; i < fixture.TestArray0.Length; i++)
            {
                Assert.True(stack.Count == i);
                stack.Push(fixture.TestArray0[i]);
                Assert.False(stack.IsEmpty);
                Assert.True(stack.Peek() == fixture.TestArray0[i]);
            }

            for (var i = fixture.TestArray0.Length - 1; i >= 0; i--)
            {
                Assert.False(stack.IsEmpty);
                Assert.True(stack.Count == i + 1);
                Assert.True(fixture.TestArray0[i] == stack.Peek());
                Assert.True(fixture.TestArray0[i] == stack.Pop());
            }

            Assert.True(stack.IsEmpty);
            Assert.True(stack.Count == 0);
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }
    }

    public class StackSinglyLinkedListTests : StackTests
    {
        protected override IStack<T> GetStackImplementation<T>()
        {
            return new StackSinglyLinkedList<T>();
        }
    }

    public class StackArrayTests : StackTests
    {
        protected override IStack<T> GetStackImplementation<T>()
        {
            // Instantiate a big enough array.
            return new StackArray<T>(99);
        }

        [Fact]
        public void FullStackArrayTests0()
        {
            var stackArray = new StackArray<int>(5);
            for(var i = 0; i < 5; i++)
            {
                Assert.True(stackArray.Count == i);
                stackArray.Push(i * 2);
            }
            Assert.True(stackArray.IsFull);
            Assert.False(stackArray.IsEmpty);
            Assert.Throws<InvalidOperationException>(() => stackArray.Push(10));
            Assert.Throws<InvalidOperationException>(() => stackArray.Push(12));
            Assert.True(stackArray.Peek() == 8);
            Assert.True(stackArray.Pop() == 8);
            Assert.True(stackArray.Count == 4);
            Assert.True(stackArray.Length == 5);
            Assert.False(stackArray.IsFull);
            Assert.False(stackArray.IsEmpty);
            stackArray.Push(8);
            Assert.True(stackArray.Peek() == 8);
            Assert.Throws<InvalidOperationException>(() => stackArray.Push(10));
            Assert.True(stackArray.IsFull);
            Assert.False(stackArray.IsEmpty);
            Assert.True(stackArray.Length == 5);
            Assert.True(stackArray.Count == 5);
        }
    }
}
