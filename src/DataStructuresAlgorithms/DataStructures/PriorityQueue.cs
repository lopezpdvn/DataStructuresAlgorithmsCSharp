using System;

namespace DataStructuresAlgorithms.AbstractDataTypes
{
    public class PriorityQueueIntArray : Queue<int>
    {
        private int[] arr;
        public int Count { get; private set; } = 0;
        public int Length { get; private set; }

        public bool IsEmpty => Count == 0;
        public bool IsFull => Length == Count;

        public PriorityQueueIntArray(int length = 64)
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

                var i = Count - 1;
                for (; i >= 0 && item > arr[i]; i--)
                {
                    arr[i + 1] = arr[i];
                }
                arr[i + 1] = item;
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
