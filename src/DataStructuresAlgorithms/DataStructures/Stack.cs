using DataStructuresAlgorithms.DataStructures.LinkedList;
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

    public class StackArray<T> : Stack<T>
    {
        public readonly int MaxSize;
        private T[] arr;
        private int top;

        public StackArray(int maxSize)
        {
            MaxSize = maxSize;
            arr = new T[MaxSize];
            top = -1;
        }

        public bool IsEmpty => top == -1;
        public bool IsFull => top == MaxSize - 1;
        public int Length => top + 1;

        public T Peek()
        {
            try
            {
                return arr[top];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException("Stack is Empty.");
            }
        }

        public T Pop()
        {
            T rt = Peek();
            top--;
            return rt;
        }

        public void Push(T value)
        {
            try
            {
                arr[top+1] = value;
                top++;
            }
            catch(IndexOutOfRangeException)
            {
                throw new InvalidOperationException("Stack is full");
            }
        }
    }
}
