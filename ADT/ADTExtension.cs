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

    //Forsøg på øvelse 2.2 i Ex60 ExtensionMethods

    //Udskriver den samlede alder
    //int sum = 0;
    //memberList.ForEach(x => sum += x);
    //console.writeline(sum);

    //Udskriver det fulde navn på alle i listen
    //memberList.ForEach(x => console.writeline(x.FirstName + x.LastName));

    //Udskriver alle mænd i listen
    //memberList.ForEach(x => 
    //{
    //    if (x.Gender == Gender.Male)
	   // {
    //        console.writeline(x.FirstName + x.LastName);
	   // }
    //});
}
