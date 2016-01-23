using DataStructuresAlgorithms.DataStructures.LinkedList.SinglyLinkedList;
using System;

namespace DataStructuresAlgorithms.AbstractDataTypes
{
    public interface IQueue<T>
    {
        bool IsEmpty { get; }
        int Count { get; }
        int Length { get; }
        T Dequeue();
        void Enqueue(T item);
        T Peek();
        void Clear();
    }

    public class QueueSinglyLinkedList<T> : SinglyLinkedList<T>, IQueue<T>
    {
        public T Dequeue()
        {
            T value = Peek();
            RemoveFirst();
            return value;
        }

        public T Peek()
        {
            try
            {
                return FirstNode.Value;
            }
            catch (NullReferenceException)
            {
                throw new InvalidOperationException("Queue is Empty.");
            }
        }

        public void Enqueue(T value)
        {
            AddLast(value);
        }
    }

    public class CircularArrayQueue<T> : IQueue<T>
    {
        public int Length { get; private set; }
        private T[] arr;
        private int head, tail;
        public int Count { get; private set; }

        public CircularArrayQueue(int length = 64)
        {
            Length = length;
            arr = new T[Length];
            Clear();
        }

        public bool IsEmpty => Count == 0;
        public bool IsFull => Count == Length;

        public T Dequeue()
        {
            T tmp = Peek();
            if(++head == Length)
            {
                head = 0;
            }
            Count--;
            return tmp;
        }

        public void Enqueue(T value)
        {
            if(IsFull)
            {
                throw new InvalidOperationException("Queue is full");
            }
            if(tail == Length - 1)
            {
                tail = -1;
            }
            arr[++tail] = value;
            Count++;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return arr[head];
        }

        public void Clear()
        {
            head = 0;
            tail = -1;
            Count = 0;
        }
    }
}
