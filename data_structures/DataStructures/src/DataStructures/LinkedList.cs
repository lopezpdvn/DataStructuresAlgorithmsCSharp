using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures;
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

        public Node<T> AddAfter(Node<T> node, T value)
        {
            var newNode = new Node<T>(value);
            Node<T> nodeInList = GetNode(node);
            if (nodeInList == null)
            {
                throw new InvalidOperationException("node " + node.Value + "not in list");
            }

            newNode.Next = nodeInList.Next;
            nodeInList.Next = newNode;

            return newNode;
        }

        public bool Contains(Node<T> node)
        {
            var isContained = false;
            foreach(var iNode in this)
            {
                if (iNode == node)
                {
                    isContained = true;
                    break;
                }
            }
            return isContained;
        }

        public void RemoveFirst()
        {
            FirstNode = FirstNode.Next;
            // destruction of old FirstNode by GC
        }

        public void Remove(Node<T> node)
        {
            Node<T> prev2Node2Remove = null;
            foreach(var iNode in this)
            {
                if(iNode.Next != null && iNode.Next == node)
                {
                    prev2Node2Remove = iNode;
                }
            }

            if (prev2Node2Remove == null)
            {
                throw new InvalidOperationException("node " + node.Value + "not in list");
            }

            // prev2Node2Remove.Next == node
            prev2Node2Remove.Next = node.Next;
        }

        public void RemoveLast()
        {
            //Node<T> nextToLast = null;
            //foreach(var node in this)   
            //{
            //    nextToLast = node;
            //    if(node.Next != null && node.Next.Next == null)
            //    {
            //        break;
            //    }
            //}

            //// list empty
            //if (nextToLast == null) return;

            //LastNode = nextToLast;
            //LastNode.Next = null;
            Remove(LastNode);
        }

        private Node<T> GetNode(Node<T> node)
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

        public Node<T> LastNode { get; set; }
        public Node<T> FirstNode { get; set; }
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

    public static class Program
    {
        static internal void Main(string data_fp)
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