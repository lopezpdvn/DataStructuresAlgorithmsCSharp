using System.Collections.Generic;
using DataStructuresAlgorithms.DataStructures.LinkedList;
using DataStructuresAlgorithms.AbstractDataTypes;

namespace DataStructuresAlgorithms.DataStructures.Graph
{
    public interface INode<T> : IEnumerable<INode<T>>
    {
        int Count { get; }
        T Vertex { get; set; }
        State State { get; set; }
        void AddAdjacent(params INode<T>[] nodes);
    }

    public interface IGraph<T> : IEnumerable<INode<T>>
    {
        ILinkedList<INode<T>> Nodes { get; }
        int Count { get; }
        IQueue<INode<T>> Queue { get; set; }
        IStack<INode<T>> Stack { get; set; }

        void FlagNodes(State state);
        void FlagNodesUnvisited();
        void Add(INode<T> node);
    }

    public enum State
    {
        Unvisited, Visited
    }
}
