using System.Collections.Generic;

namespace DataStructuresAlgorithms.DataStructures.LinkedList
{
    public interface LinkedList<T> : IEnumerable<Node<T>>
    {
        Node<T> LastNode { get; }
        Node<T> FirstNode { get; }
        Node<T> Add(T value);
        bool IsEmpty { get; }
        int Length { get; }
        int Count { get; }

        Node<T> AddFirst(T value);
        Node<T> AddLast(T value);
        Node<T> AddBefore(Node<T> node, T value);
        Node<T> AddAfter(Node<T> node, T value);
        bool Contains(Node<T> node);
        void RemoveFirst();
        void Remove(Node<T> node);
        //Node<int> Remove(int key);
        void RemoveBefore(Node<T> node);
        void RemoveAfter(Node<T> node);
        void RemoveLast();
        void Clear();
        Node<T> Find(Node<T> node);
        //int Find(int key);
        Node<T> FindPrevious(Node<T> node);
        //Node<int> FindPrevious(int key);
        Node<T> FindMToLast(int m);
        bool IsCyclic { get; }
    }

    public interface Node<T>
    {
        Node<T> Next { get; set; }
        Node<T> Prev { get; set; }
        T Value { get; }
    }
}