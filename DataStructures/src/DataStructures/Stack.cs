using DataStructures.LinkedList;
using System;
using System.Collections.Generic;

namespace AbstractDataType
{
    public interface Stack<T>
    {
        void Push(T value);
        T Pop();
    }

    public class StackSinglyLinkedList<T> : SinglyLinkedList<T>, Stack<T>
    {
        public T Pop()
        {
            try
            {
                T value = FirstNode.Value;
                RemoveFirst();
                return value;
            }
            catch (NullReferenceException)
            {
                throw new InvalidOperationException("Stack is Empty, Pop failed.");
            }
        }

        public void Push(T value)
        {
            AddFirst(value);
        }
    }
}
