using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.LinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public class Node(T value)
        {
            public T Value { get; } = value;
            public Node Next;
            public Node Prev;
        }

        private Node head;
        private Node tail;
        public int Count { get; private set; }

        // Add at the end
        public void AddLast(T value)
        {
            var newNode = new Node(value);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            Count++;
        }

        // Add at the beginning
        public void AddFirst(T value)
        {
            var newNode = new Node(value);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
            Count++;
        }

        // Remove first occurrence of value
        public bool Remove(T value)
        {
            var current = head;
            while (current != null)
            {
                if (Equals(current.Value, value))
                {
                    if (current.Prev != null)
                        current.Prev.Next = current.Next;
                    else
                        head = current.Next;

                    if (current.Next != null)
                        current.Next.Prev = current.Prev;
                    else
                        tail = current.Prev;

                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        // Remove first node
        public bool RemoveFirst()
        {
            if (head == null) return false;

            if (head.Next != null)
            {
                head = head.Next;
                head.Prev = null;
            }
            else
            {
                head = tail = null;
            }
            Count--;
            return true;
        }

        // Remove last node
        public bool RemoveLast()
        {
            if (tail == null) return false;

            if (tail.Prev != null)
            {
                tail = tail.Prev;
                tail.Next = null;
            }
            else
            {
                head = tail = null;
            }
            Count--;
            return true;
        }

        // Find first node with the given value
        public Node Find(T value)
        {
            var current = head;
            while (current != null)
            {
                if (Equals(current.Value, value))
                    return current;
                current = current.Next;
            }
            return null;
        }

        // Clear list
        public void Clear()
        {
            head = tail = null;
            Count = 0;
        }

        // Enumerate from head to tail
        public IEnumerable<T> EnumerateForward()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        // Enumerate from tail to head
        public IEnumerable<T> EnumerateBackward()
        {
            var current = tail;
            while (current != null)
            {
                yield return current.Value;
                current = current.Prev;
            }
        }

        // Print list forward
        public void PrintForward()
        {
            Console.WriteLine(string.Join(" <-> ", EnumerateForward()));
        }

        // Print list backward
        public void PrintBackward()
        {
            Console.WriteLine(string.Join(" <-> ", EnumerateBackward()));
        }
    }

}
