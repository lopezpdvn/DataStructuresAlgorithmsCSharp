namespace DataStructuresAlgorithms.DataStructures.Tree.BinaryTree.BinarySearchTree
{
    public class BinarySearchTreeInt
    {

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

        public static bool operator == (NodeInt a, NodeInt b)
            => a.Value == b.Value;

        public static bool operator != (NodeInt a, NodeInt b)
            => a.Value != b.Value;
    }
}
