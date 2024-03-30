using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment3.Utility
{
    public class CannotRemoveException : Exception
    {
        public CannotRemoveException(string message) : base(message)
        {
        }
    }
    [DataContract]
    [KnownType(typeof(Node))]
    [KnownType(typeof(User))]
    public class SLL : ILinkedListADT
    {
        public Node head;
        public int size;

        public SLL()
        {
            head = null;
            size = 0;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Clear()
        {
            head = null;
            size = 0;
        }

        public void AddLast(User value)
        {
            if (head == null)
            {
                head = new Node(value);
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node(value);
            }
            size++;
        }

        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            newNode.Next = head;
            head = newNode;
            size++;
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == size)
            {
                AddLast(value);
            }
            else
            {
                Node newNode = new Node(value);
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
                size++;
            }
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Data = value;
        }

        public int Count()
        {
            int count = 0;
            Node current = head;

            while (current != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }
        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new CannotRemoveException("Cannot remove from an empty list.");
            }
            head = head.Next;
            size--;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new CannotRemoveException("Cannot remove from an empty list.");
            }
            if (size == 1)
            {
                head = null;
            }
            else
            {
                Node current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
            size--;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == size - 1)
            {
                RemoveLast();
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
                size--;
            }
        }

        public User GetValue(int index)
        {
            if(index < 0 || index >= Count())
        {
                throw new ArgumentOutOfRangeException("index");
            }

            Node current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public int IndexOf(User value)
        {
            int index = 0;
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }

        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }

        // Reverse the order of the nodes in the linked list
        public void Reverse()
        {
            if (IsEmpty() || size == 1)
            {
                return;
            }

            Node prev = null;
            Node current = head;
            Node next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }

        // Copy the values of the linked list nodes into an array
        public User[] ToArray()
        {
            User[] array = new User[size];
            Node current = head;
            int index = 0;
            while (current != null)
            {
                array[index] = current.Data;
                current = current.Next;
                index++;
            }
            return array;
        }
    }
}
