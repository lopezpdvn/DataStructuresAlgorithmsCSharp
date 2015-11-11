using System;
using Xunit;
using DataStructuresAlgorithms.AbstractDataTypes;

namespace DataStructuresAlgorithms.Tests.DataStructures
{
    public class StackTests
    {
        [Fact]
        public void StackSinglyLinkedListTest0()
        {
            var fixture = new { TestArray0 = new int[] { 3, 6, 9, 12 } };
            Stack<int> stack = new StackSinglyLinkedList<int>();
            Assert.True(stack.IsEmpty);
            Assert.True(stack.Length == 0);
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
            Assert.Throws<InvalidOperationException>(() => stack.Peek());

            for(var i = 0; i < fixture.TestArray0.Length; i++)
            {
                Assert.True(stack.Length == i);
                stack.Push(fixture.TestArray0[i]);
                Assert.False(stack.IsEmpty);
            }

            for(var i = fixture.TestArray0.Length - 1; i >= 0 ; i--)
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
}
