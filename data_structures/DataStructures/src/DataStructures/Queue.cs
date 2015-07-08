using DataStructures.LinkedList;
using System;
using System.Collections.Generic;

namespace AbstractDataType
{
    public interface Queue<T>
    {
        T Dequeue();
        void Enqueue(T value);
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
                T value = FirstNode.Value;
                return value;
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
