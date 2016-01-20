using System.Collections.Generic;

namespace DataStructuresAlgorithms.DataStructures.Tree
{
    public interface INode<T>
    {
        INode<T> Left { get; set; }
        INode<T> Right { get; set; }
        T Value { get; set; }
        IEnumerable<INode<T>> EnumerateLR();
        IEnumerable<INode<T>> EnumerateRL();
    }
}
