using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAlgorithms.DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : LinkedList<T>
    {
        public SinglyLinkedList(T value)
        {
            FirstNode = LastNode = new SinglyLinkedNode<T>(value);
        }

        public SinglyLinkedList() { }
        public Node<T> LastNode { get; set; }
        public Node<T> FirstNode { get; set; }
        public Node<T> Add(T value) => AddLast(value);
        public bool IsEmpty => Count == 0;
        public int Length => Count;
        public int Count { get; private set; }

        public Node<T> AddFirst(T value) {
            var newFirstNode = new SinglyLinkedNode<T>(value);

            if(FirstNode == null)
            {
                // Empty list
                FirstNode = LastNode = newFirstNode;
            }
            else
            {
                newFirstNode.Next = FirstNode;
                FirstNode = newFirstNode;
            }

            Count++;
            return newFirstNode;
        }

        public Node<T> AddLast(T value) {
            var newLastNode = new SinglyLinkedNode<T>(value);

            if(FirstNode == null)
            {
                // list is empty
                FirstNode = LastNode = newLastNode;
            }
            else
            {
                LastNode.Next = newLastNode;
                LastNode = newLastNode;
            }

            Count++;
            return newLastNode;
        }

        public Node<T> AddBefore(Node<T> node, T value)
        {
            if(FirstNode == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            else if (FirstNode == node)
            {
                // There's no previous node since it's the first one, possibly because this.Count == 1.
                return AddFirst(value);
            }
            else
            {
                Node<T> prevNode = FindPrevious(node);
                if (prevNode == null)
                {
                    throw new InvalidOperationException("node " + node.Value + "not in list");
                }

                Node<T> newNode = new SinglyLinkedNode<T>(value);
                newNode.Next = node;
                prevNode.Next = newNode;
                Count++;
                return newNode;
            }
        }

        public Node<T> AddAfter(Node<T> node, T value)
        {
            var newNode = new SinglyLinkedNode<T>(value);
            node = Find(node);
            try
            {
                newNode.Next = node.Next;
                if(LastNode == node)
                {
                    LastNode = newNode;
                }
                node.Next = newNode;
                Count++;
                return newNode;
            }
            catch(NullReferenceException)
            {
                throw new InvalidOperationException(
                    "node " + node.Value + "not in list");
            }
        }

        public bool Contains(Node<T> node) => Find(node) != null;

        public void RemoveFirst()
        {
            try
            {
                FirstNode = FirstNode.Next;
                Count--;
                // destruction of old FirstNode by GC
            }
            catch (NullReferenceException)
            {
                throw new InvalidOperationException("List is empty");
            }
        }

        public void Remove(Node<T> node)
        {
            Node<T> prev2Node2Remove = FindPrevious(node);

            try
            {
                // prev2Node2Remove.Next == node
                prev2Node2Remove.Next = node.Next;
                Count--;
            }
            catch(NullReferenceException)
            {
                throw new InvalidOperationException("node " + node.Value +
                    "not in list");
            }
        }

        public static Node<int> Remove(int key, SinglyLinkedList<int> list)
        {
            Node<int> node = null;
            try
            {
                Node<int> prev2Node = FindPrevious(key, list);
                node = prev2Node.Next;
                prev2Node.Next = node.Next;
                list.Count--;
            }
            catch (NullReferenceException)
            {
                throw new InvalidOperationException("node with" + key +
                    "not in list");
            }

            return node;
        }

        public void RemoveBefore(Node<T> node)
        {
            Node<T> node2Remove = FindPrevious(node);
            if(node2Remove == null)
            {
                if(FirstNode == node)
                {
                    // node is first Node
                    throw new InvalidOperationException("node " + node + "is first in list.");
                }
                else 
                {
                    // Find(node) == null
                    throw new InvalidOperationException("node " + node + "not in list.");
                }
            }
            else if (node2Remove == FirstNode)
            {
                RemoveFirst();
            }
            else
            {
                Node<T> nodePrev2Remove = FindPrevious(node2Remove);
                nodePrev2Remove.Next = node;
                node2Remove.Next = null;
                Count--;
            }
        }

        public void RemoveAfter(Node<T> node)
        {
            Node<T> nodeInList = Find(node);
            if (nodeInList == null)
            {
                throw new InvalidOperationException("node " + node + "not in list.");
            }
            else if (nodeInList.Next == null)
            {
                throw new InvalidOperationException("node " + node + "is last in list.");
            }
            else if (nodeInList.Next.Next == null)
            {
                // Removing last node.
                nodeInList.Next = null;
                Count--;
            }
            else
            {
                // Removing next node, which is not the last one.
                nodeInList.Next = nodeInList.Next.Next;
                Count--;
            }
        }

        public void RemoveLast() => Remove(LastNode);

        public void Clear() => FirstNode = LastNode = null;

        public Node<T> Find(Node<T> node)
        {
            Node<T> iNode = FirstNode;
            while(iNode != null && iNode != node)
            {
                iNode = iNode.Next;
            }

            return iNode;
        }

        public static int? Find(int key, SinglyLinkedList<int> list)
        {
            var iNode = list.FirstNode;
            while(iNode != null && iNode.Value != key)
            {
                iNode = iNode.Next;
            }

            return iNode?.Value;
        }

        public Node<T> FindPrevious(Node<T> node)
        {
            Node<T> prevNode = null, iNode = FirstNode;

            while (iNode != null && iNode != node)
            {
                prevNode = iNode;
                iNode = prevNode.Next;
            }

            return iNode == null ? null : prevNode;
        }

        private static Node<int> FindPrevious(int key,
            SinglyLinkedList<int> list)
        {
            Node<int> prevNode = null, iNode = list.FirstNode;

            while (iNode != null && iNode.Value != key)
            {
                prevNode = iNode;
                iNode = prevNode.Next;
            }

            return iNode == null ? null : prevNode;
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            var currentNode = FirstNode;
            while (currentNode != null)
            {
                yield return currentNode;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.AppendFormat("{0} with members: ", GetType().Name);
            int i = 0;
            foreach (var iNode in this)
            {
                strBuild.AppendFormat("{0} -> ", iNode);
                i++;
            }
            strBuild.Append("NULL");
            return strBuild.ToString();
        }

        public Node<T> FindMToLast(int m)
        {
            Node<T> mBehind, current;
            current = FirstNode;

            for (int i = 0; i < m; i++)
            {
                if(current.Next == null)
                {
                    throw new InvalidOperationException("List size < " + m);
                }
                current = current.Next;
            }

            mBehind = FirstNode;
            while(current.Next != null)
            {
                current = current.Next;
                mBehind = mBehind.Next;
            }

            return mBehind;
        }

        public bool IsCyclic
        {
            get
            {
                try
                {
                    Node<T> fast, slow;
                    slow = FirstNode;
                    fast = FirstNode.Next;
                    while (true)
                    {
                        if (fast == null || fast.Next == null)
                        {
                            return false;
                        }
                        else if (fast == slow || fast.Next == slow)
                        {
                            return true;
                        }
                        else
                        {
                            slow = slow.Next;
                            fast = fast.Next.Next;
                        }
                    }
                }
                catch(NullReferenceException)
                {
                    return false;
                }
            }
        }
    }

    public class SinglyLinkedNode<T> : Node<T>
    {
        public SinglyLinkedNode() { }

        public SinglyLinkedNode(T value)
        {
            Value = value;
        }

        public Node<T> Next { get; set; }

        public Node<T> Prev
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public T Value { get; set; }
        public override string ToString() => Value.ToString();
    }

    public static class Cfg
    {
        public const string SEP = "\n=================== ";
    }

    public static class Program
    {
        static internal void MiscTests(string data_fp)
        {
            Console.WriteLine("{0}Linked list program", Cfg.SEP);
            var linkedList0 = new SinglyLinkedList<string>{ "first original element", "new first element" };

            Console.WriteLine("{0}Printing whole list", Cfg.SEP);
            Console.WriteLine(linkedList0);

            Console.WriteLine("{0} -> {1}", linkedList0.FirstNode.Value, linkedList0.FirstNode.Next.Value);


            linkedList0.AddLast("new last element");
            foreach (var node in linkedList0)
            {
                Console.WriteLine(node.Value);
            }

            Console.WriteLine();
            linkedList0.RemoveLast();
            foreach (var node in linkedList0)
            {
                Console.WriteLine(node.Value);
            }

            Console.WriteLine();
            var linkedListInts = new SinglyLinkedList<int>(){ 0, 1, 2, 3, 4};
            Console.WriteLine(Cfg.SEP + "All linkedListInts");
            Console.WriteLine(linkedListInts);

            Console.WriteLine(Cfg.SEP + "Remove middle (2)");
            linkedListInts.Remove(linkedListInts.FirstNode.Next.Next);
            Console.WriteLine(linkedListInts);

            Console.WriteLine(Cfg.SEP + "Remove last (4)");
            linkedListInts.RemoveLast();
            Console.WriteLine(linkedListInts);

            Console.WriteLine(Cfg.SEP + "Remove first (0)");
            linkedListInts.RemoveFirst();
            Console.WriteLine(linkedListInts);

            Console.Read();
        }
    }
}