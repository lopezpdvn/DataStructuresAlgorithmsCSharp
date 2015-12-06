using DataStructuresAlgorithms.DataStructures.LinkedList;
using System;

namespace DataStructuresAlgorithms.AbstractDataTypes
{
    public interface Queue<T>
    {
        T Dequeue();
        void Enqueue(T value);
        T Peek();
        bool IsEmpty { get; }
        int Length { get; }
    }

    public class QueueSinglyLinkedList<T> : SinglyLinkedList<T>, Queue<T>
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

    public class CircularArrayQueue<T> : Queue<T>
    {
        public readonly int MaxSize;
        private T[] arr;
        private int head, tail, nItems;

        public CircularArrayQueue(int maxSize)
        {
            MaxSize = maxSize;
            arr = new T[MaxSize];
            head = 0;
            tail = -1;
            nItems = 0;
        }

        public bool IsEmpty => nItems == 0;
        public int Length => nItems;
        public bool IsFull => nItems == MaxSize;

        public T Dequeue()
        {
            T tmp = Peek();
            if(++head == MaxSize)
            {
                head = 0;
            }
            nItems--;
            return tmp;
        }

        public void Enqueue(T value)
        {
            if(IsFull)
            {
                throw new InvalidOperationException("Queue is full");
            }
            if(tail == MaxSize - 1)
            {
                tail = -1;
            }
            arr[++tail] = value;
            nItems++;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return arr[head];
        }
    }
}
