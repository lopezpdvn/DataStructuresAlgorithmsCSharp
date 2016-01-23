using System.Collections.Generic;

namespace DataStructuresAlgorithms.DataStructures.LinkedList
{
    public interface ILinkedList<T> : IEnumerable<INode<T>>
    {
        INode<T> LastNode { get; }
        INode<T> FirstNode { get; }
        INode<T> Add(T value);
        bool IsEmpty { get; }
        int Length { get; }
        int Count { get; }

        INode<T> AddFirst(T value);
        INode<T> AddLast(T value);
        INode<T> AddBefore(INode<T> node, T value);
        INode<T> AddAfter(INode<T> node, T value);
        bool Contains(INode<T> node);
        INode<T> RemoveFirst();
        INode<T> Remove(INode<T> node);
        //Node<int> Remove(int key);
        INode<T> RemoveBefore(INode<T> node);
        INode<T> RemoveAfter(INode<T> node);
        INode<T> RemoveLast();
        void Clear();
        INode<T> Find(INode<T> node);
        //int Find(int key);
        INode<T> FindPrevious(INode<T> node);
        //Node<int> FindPrevious(int key);
        INode<T> FindMToLast(int m);
        bool IsCyclic { get; }
    }

    public interface INode<T>
    {
        INode<T> Next { get; set; }
        INode<T> Prev { get; set; }
        T Value { get; }
    }
}