using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<Node<T>>
    {
        public SinglyLinkedList(T value)
        {
            FirstNode = LastNode = new Node<T>(value);
        }

        public Node<T> AddFirst(T value) {
            var newFirstNode = new Node<T>(value);
            newFirstNode.Next = FirstNode;
            FirstNode = newFirstNode;
            return newFirstNode;
        }

        public Node<T> AddLast(T value) {
            var newLastNode = new Node<T>(value);
            LastNode.Next = newLastNode;
            LastNode = newLastNode;
            return newLastNode;
        }

        public Node<T> AddAfter(Node<T> node, T value)
        {
            var newNode = new Node<T>(value);
            Node<T> nodeInList = null;
            foreach(var iNode in this)
            {
                if(iNode == node)
                {
                    nodeInList = iNode;
                    break;
                }
            }

            if (nodeInList == null)
            {
                throw new InvalidOperationException("node {0} not in list");
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

        public void RemoveLast()
        {
            Node<T> nextToLast = null;
            foreach(var node in this)   
            {
                nextToLast = node;
                if(node.Next != null && node.Next.Next == null)
                {
                    break;
                }
            }

            // list empty
            if (nextToLast == null) return;

            LastNode = nextToLast;
            LastNode.Next = null;
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

        private Node<T> next;
        private T data;
    }

    public static class Program
    {
        static internal void Main(string data_fp)
        {
            Console.WriteLine("Linked list program");
            var linkedList0 = new SinglyLinkedList<string>("first original element");
            linkedList0.AddFirst("new first element");

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

            Console.Read();
        }
    }
}