using System;
using DataStructuresAlgorithms.DataStructures.Array;

namespace DataStructuresAlgorithms.AbstractDataTypes
{
    public interface IPriorityQueue<T> : IQueue<T> { }

    public class PriorityQueueIntSortedArray :
        SortedArrayInt, IPriorityQueue<int>
    {
        public PriorityQueueIntSortedArray(int length = 64) : base(length) { }

        public bool IsEmpty => Count == 0;
        public bool IsFull => Length == Count;

        public void Clear() => Count = 0;

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
                Insert(item);
            }
            catch(InvalidOperationException)
            {
                throw new InvalidOperationException("Priority Queue is full");
            }

        }

        public int Peek()
        {
            try
            {
                return this[Count - 1];
            }
            catch(IndexOutOfRangeException)
            {
                throw new InvalidOperationException("Priority Queue is empty");
            }
        }
    }
}
