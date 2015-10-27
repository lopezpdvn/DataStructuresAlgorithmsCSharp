using DataStructures.LinkedList;
using System;
using System.Collections.Generic;

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
}
