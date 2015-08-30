using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DataStructures.LinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<Node<T>>
    {
        public SinglyLinkedList(T value)
        {
            FirstNode = LastNode = new Node<T>(value);
        }

        public SinglyLinkedList() { }

        public void Add(T value)
        {
            AddLast(value);
        }

        public int Count
        {
            get
            {
                int n = 0;
                foreach (var iNode in this)
                {
                    n++;
                }
                return n;
            }
        }

        public Node<T> AddFirst(T value) {
            var newFirstNode = new Node<T>(value);

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

            return newFirstNode;
        }

        public Node<T> AddLast(T value) {
            var newLastNode = new Node<T>(value);

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

                Node<T> newNode = new Node<T>(value);
                newNode.Next = node;
                prevNode.Next = newNode;
                return newNode;
            }
        }

        public Node<T> AddAfter(Node<T> node, T value)
        {
            var newNode = new Node<T>(value);
            Node<T> nodeInList = Find(node);
            if (nodeInList == null)
            {
                throw new InvalidOperationException("node " + node.Value + "not in list");
            }

            newNode.Next = nodeInList.Next;
            nodeInList.Next = newNode;

            return newNode;
        }

        public Node<T> FindPrevious(Node<T> node)
        {
            Node<T> prevNode = null;
            foreach (var iNode in this)
            {
                if (iNode.Next != null && iNode.Next == node)
                {
                    prevNode = iNode;
                }
            }

            return prevNode;
        }

        public bool Contains(Node<T> node)
        {
            return Find(node) != null;
        }

        public void RemoveFirst()
        {
            try
            {
                FirstNode = FirstNode.Next;
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

            if (prev2Node2Remove == null)
            {
                throw new InvalidOperationException("node " + node.Value + "not in list");
            }

            // prev2Node2Remove.Next == node
            prev2Node2Remove.Next = node.Next;
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
            }
            else
            {
                // Removing next node, which is not the last one.
                nodeInList.Next = nodeInList.Next.Next;
            }
        }

        public void RemoveLast()
        {
            Remove(LastNode);
        }

        public void Clear()
        {
            FirstNode = LastNode = null;
        }

        public Node<T> Find(Node<T> node)
        {
            Node<T> nodeInList = null;
            foreach (var iNode in this)
            {
                if (iNode == node)
                {
                    nodeInList = iNode;
                    break;
                }
            }

            return nodeInList;
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

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

        public Node<T> LastNode { get; set; }
        public Node<T> FirstNode { get; set; }

        public static bool IsCyclic(SinglyLinkedList<T> list)
        {
            Node<T> fast, slow;
            slow = list.FirstNode;
            fast = list.FirstNode.Next;
            while (true)
            {
                if(fast == null || fast.Next == null)
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
    }

    public class Node<T>
    {
        public Node(T value)
        {
            data = value;
        }

        public Node<T> Next
        {
            get { return next; }
            set { next = value;  }
        }

        public T Value
        {
            get { return data; }
            set { data = value; }
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        private Node<T> next;
        private T data;
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

        static internal void TestFindMToLastElement(string data_fp)
        {
            var list = new SinglyLinkedList<int> {0,1,2,3,4,5,6,7,8,9,10,11,12};
            Console.WriteLine(list);

            var m = list.FindMToLast(7);
            Console.WriteLine("{0} = 5", m);
        }

        static internal void TestIsCyclic()
        {
            var list = new SinglyLinkedList<int>();
            for (int i = 0; i < 20; i++)
            {
                list.AddLast(i);
            }
            Console.WriteLine(list);
            Debug.Assert(list.LastNode.Next == null);

            Debug.Assert(!SinglyLinkedList<int>.IsCyclic(list));

            // making list cyclic
            var middleNode = list.FirstNode.Next.Next.Next;
            list.LastNode.Next = middleNode;
            Debug.Assert(list.LastNode.Next == list.FirstNode.Next.Next.Next);

            Console.WriteLine("IsCyclic = {0}", SinglyLinkedList<int>.IsCyclic(list));
            //Debug.Assert(SinglyLinkedList<int>.IsCyclic(list));
        }
    }
}