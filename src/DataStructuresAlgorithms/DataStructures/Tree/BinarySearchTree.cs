using DataStructuresAlgorithms.AbstractDataTypes;
using System.Collections.Generic;

namespace DataStructuresAlgorithms.DataStructures.Tree.BinaryTree.BinarySearchTree
{
    public class BinarySearchTreeInt
    {
        public NodeInt Root { get; private set; }

        public void Insert(NodeInt newNode)
        {
            if(Root == null)
            {
                Root = newNode;
                return;
            }
            NodeInt parent = null, node = Root;
            while(true)
            {
                parent  = node;
                if(newNode < node)
                {
                    node = (NodeInt)node.Left;
                    if(node == null)
                    {
                        parent.Left = newNode;
                        return;
                    }
                }
                else
                {
                    node = (NodeInt)node.Right;
                    if(node == null)
                    {
                        parent.Right = newNode;
                        return;
                    }
                }
            }
        }

        public IEnumerable<NodeInt> IODFTraversal()
        {
            var stack = new StackSinglyLinkedList<INode<int>>();
            foreach(var i in
                BinaryTree<int>.InOrderTraversalIterativeIterator(Root, stack))
            {
                yield return (NodeInt)i;
            }
        }

        public NodeInt Find(NodeInt target)
        {
            var node = Root;
            while(node != null && node.Value != target.Value)
            {
                if(target < node)
                {
                    node = (NodeInt)node.Left;
                }
                else
                {
                    node = (NodeInt)node.Right;
                }
            }
            return node;
        }
    }

    public class NodeInt : Node<int>
    {   
        public NodeInt(int value = 0) : base(null, null, value) {}

        public static bool operator < (NodeInt a, NodeInt b)
            => a.Value < b.Value;

        public static bool operator <= (NodeInt a, NodeInt b)
            => a.Value <= b.Value;

        public static bool operator >= (NodeInt a, NodeInt b)
            => a.Value >= b.Value;

        public static bool operator > (NodeInt a, NodeInt b)
            => a.Value > b.Value;
    }
}
