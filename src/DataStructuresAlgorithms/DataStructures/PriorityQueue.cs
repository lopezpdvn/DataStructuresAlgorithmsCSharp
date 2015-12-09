using System;

namespace DataStructuresAlgorithms.AbstractDataTypes
{
    public interface PriorityQueue<T>
    {
        T Dequeue();
        void Enqueue(T item);
        T Peek();
        bool IsEmpty { get; }
        int Count { get; }
        int Length { get; }
    }

    public class PriorityQueueIntArray : PriorityQueue<int>
    {
        private int[] arr;
        public int Count { get; private set; } = 0;
        public int Length { get; private set; }

        public bool IsEmpty => Count == 0;
        public bool IsFull => Length == Count;

        public PriorityQueueIntArray(int length)
        {
            Length = length;
            arr = new int[Length];
        }

        public int Dequeue()
        {
            var tmp = Peek();
            Count--;
            return tmp;
        }

        public void Enqueue(int item)
        {
            try
            {
                if (IsEmpty)
                {
                    arr[Count++] = item;
                    return;
                }

                for (var i = Count - 1; i >= 0; i--)
                {
                    if (item > arr[i])
                    {
                        arr[i + 1] = arr[i];
                    }
                    else
                    {
                        arr[i + 1] = item;
                    }
                }

                Count++;
            }
            catch(IndexOutOfRangeException)
            {
                throw new InvalidOperationException("Priority Queue is full");
            }

        }

        public int Peek()
        {
            try
            {
                return arr[Count - 1];
            }
            catch(IndexOutOfRangeException)
            {
                throw new InvalidOperationException("Priority Queue is empty");
            }
        }
    }
}
