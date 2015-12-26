using DataStructuresAlgorithms.DataStructures.LinkedList.SinglyLinkedList;
using System;

namespace DataStructuresAlgorithms.AbstractDataTypes
{
    public interface IStack<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
        bool IsEmpty { get; }
        int Count { get; }
        int Length { get; }
    }

    public class StackSinglyLinkedList<T> : SinglyLinkedList<T>, IStack<T>
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

    public class StackArray<T> : IStack<T>
    {
        public int Length { get; private set; }
        private T[] arr;
        private int top;

        public StackArray(int length = 64)
        {
            Length = length;
            arr = new T[length];
            top = -1;
        }

        public bool IsEmpty => top == -1;
        public bool IsFull => top == Length - 1;
        public int Count => top + 1;

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
