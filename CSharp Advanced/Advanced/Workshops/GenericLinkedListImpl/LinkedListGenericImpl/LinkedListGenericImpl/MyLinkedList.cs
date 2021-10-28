using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedListGenericImpl
{
    public class MyLinkedList
    {
        public int Count { get; set; }

        public Node Head { get; set; }

        public Node Tail { get; set; }

        public MyLinkedList()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        public MyLinkedList(int value)
            : this()
        {
            Node newNode = new Node()
            {
                Value = value,
                Next = null,
                Previous = null
            };

            Count++;
            Head = Tail = newNode;
        }

        public MyLinkedList(IEnumerable<int> list)
            : this(list.FirstOrDefault())
        {
            bool isFirst = true;

            foreach (var item in list)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    Node newNode = new Node()
                    {
                        Value = item,
                        Previous = Tail,
                        Next = null
                    };

                    Tail.Next = Tail;
                    Tail = newNode;
                }
            }
        }

        public void AddFirst(int element)
        {
            Node newNode = new Node()
            {
                Value = element
            };

            if (Count == 0)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head.Previous = newNode;
                Head = newNode;
            }

            Count++;
        }

        public void AddLast(int element)
        {
            Node newNode = new Node() { Value = element };

            if (Count == 0)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Previous = Tail;
                Tail.Next = newNode;
                Tail = newNode;
            }

            Count++;
        }

        public void ForEach(Action<int> action)
        {
            Node currentNode = this.Head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public int[] ToArray()
        {
            int[] result = new int[Count];
            var currentNode = Head;
            int count = 0;

            while (currentNode != null)
            {
                result[count++] = currentNode.Value;
                currentNode = currentNode.Next;
            }

            return result;
        }
    }
}
