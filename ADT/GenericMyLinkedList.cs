using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT
{
    public class MyLinkedList<T>: IEnumerable where T : IComparable<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T data)
            {
                Data = data;
            }
        }

        private Node head;

        public int Count { get; private set; }
        public T First
        {
            get { return ItemAt(0); }
        }
        public T Last
        {
            get { return ItemAt(Count - 1); }
        }

        public void Insert(T data, int index = 0)
        {
            Node n = new Node(data);
            
            if (index > Count)
                index = Count;

            if (Count == 0 || index < 1)
            {
                n.Next = head;
                head = n;
            }
            else
            {
                Node position = head;
                for (int i = 0; i < index - 1; i++)
                {
                    position = position.Next;
                }
                n.Next = position.Next;
                position.Next = n;
            }

            Count++;
        }

        public void Append(T data)
        {
            Insert(data, Count);
        }
        
        public void Delete(int index = 0)
        {
            if (Count > 0)
            {
                if (index > Count)
                    index = Count;

                if (index < 1)
                    head = head.Next;
                else
                {
                    Node position = head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        position = position.Next;
                    }
                    position.Next = position.Next.Next;
                }

                Count--;
            }
        }
        
        public T ItemAt(int index)
        {
            T result = default(T);
            if (index < Count && index >= 0)
            {
                Node position = head;
                for (int i = 0; i < index; i++)
                {
                    position = position.Next;
                }
                result = position.Data;
            }
            return result;
        }
        
        public override string ToString()
        {
            string result = "";
            Node pointernode = head;
            while (pointernode != null)
            {
                result = result + pointernode.Data.ToString() + "\n";

                pointernode = pointernode.Next;
            }
            return result;
        }

        public IEnumerator GetEnumerator()
        {
            return new MyLinkedListEnumerator(head);
        }

        public void Sort()
        {
            int n = this.Count;
            Node pointer;

            for (int i = 0; i < n - 1; i++)
            {
                pointer = head;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (pointer.Next != null)
                    {
                        if ((pointer.Data).CompareTo(pointer.Next.Data) > 0)
                        {
                            T temp = pointer.Data;
                            pointer.Data = pointer.Next.Data;
                            pointer.Next.Data = temp;
                        }
                        pointer = pointer.Next;
                    }
                }
            }
        }

        public void Sort(IComparer<T> ic)
        {
            int n = this.Count;
            Node pointer;

            for (int i = 0; i < n - 1; i++)
            {
                pointer = head;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (pointer.Next != null)
                    {
                        if (ic.Compare(pointer.Data, pointer.Next.Data) == 1)
                        {
                            T temp = pointer.Data;
                            pointer.Data = pointer.Next.Data;
                            pointer.Next.Data = temp;
                        }
                        pointer = pointer.Next;
                    }
                }
            }
        }

        private class MyLinkedListEnumerator : IEnumerator
        {
            private Node _head;
            private Node temp;
            private Node reset;

            public MyLinkedListEnumerator(Node head)
            {
                temp = null;
                _head = head;
                reset = head;
            }
            public T Current
            {
                get
                {
                    if (temp == null)
                    {
                        return default(T);
                    }
                    else
                    {
                        return temp.Data;
                    }
                }
            }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (temp == null)
                {
                    temp = _head;
                }
                else
                {
                    temp = temp.Next;
                }
                if (temp == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            public void Reset()
            {
                _head = reset;
            }
        }
    }
}
