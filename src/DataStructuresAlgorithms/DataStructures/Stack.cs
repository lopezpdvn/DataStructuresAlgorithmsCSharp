using DataStructures.LinkedList;
using System;
using System.Collections.Generic;

namespace DataStructuresAlgorithms.AbstractDataTypes
{
    public interface Stack<T>
    {
        void Push(T value);
        T Pop();
        T Peek();
        bool IsEmpty { get; }
        int Length { get; }
    }

    public class StackSinglyLinkedList<T> : SinglyLinkedList<T>, Stack<T>
    {
        public T Peek()
        {
            try
            {
                return FirstNode.Value;
            }
            catch (NullReferenceException)
            {
                throw new InvalidOperationException("Stack is Empty.");
            }
        }

        public T Pop()
        {
            T value = Peek();
            RemoveFirst();
            return value;
        }

        public void Push(T value)
        {
            AddFirst(value);
        }
    }
}
