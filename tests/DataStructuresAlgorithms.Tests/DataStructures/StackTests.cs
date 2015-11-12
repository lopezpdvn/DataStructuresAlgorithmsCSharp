using System;
using Xunit;
using DataStructuresAlgorithms.AbstractDataTypes;

namespace DataStructuresAlgorithms.Tests.DataStructures
{
    public abstract class StackTests
    {
        protected abstract Stack<T> GetStackImplementation<T>();

        [Fact]
        public void StackGeneralTest0()
        {
            Stack<int> stack = GetStackImplementation<int>();
            var fixture = new { TestArray0 = new int[] { 3, 6, 9, 12 } };
            Assert.True(stack.IsEmpty);
            Assert.True(stack.Length == 0);
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
            Assert.Throws<InvalidOperationException>(() => stack.Peek());

            for (var i = 0; i < fixture.TestArray0.Length; i++)
            {
                Assert.True(stack.Length == i);
                stack.Push(fixture.TestArray0[i]);
                Assert.False(stack.IsEmpty);
                Assert.True(stack.Peek() == fixture.TestArray0[i]);
            }

            for (var i = fixture.TestArray0.Length - 1; i >= 0; i--)
            {
                Assert.False(stack.IsEmpty);
                Assert.True(stack.Length == i + 1);
                Assert.True(fixture.TestArray0[i] == stack.Peek());
                Assert.True(fixture.TestArray0[i] == stack.Pop());
            }

            Assert.True(stack.IsEmpty);
            Assert.True(stack.Length == 0);
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }
    }

    public class StackSinglyLinkedListTests : StackTests
    {
        protected override Stack<T> GetStackImplementation<T>()
        {
            return new StackSinglyLinkedList<T>();
        }
    }
}
