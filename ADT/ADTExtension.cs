using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT
{
    public static class ADTExtension
    {
        public static void ForEach<T>(this MyLinkedList<T> list, Action<T> action) where T : IComparable<T>
        {
            foreach (T item in list)
            {
                action(item);
            }
        }
    }
}
