using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListupg
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> elements = new GenericList<int>();

            //tom lista.
            Console.WriteLine(elements);
            Console.WriteLine("Number of elements : {0}", elements.Count);
            Console.WriteLine("Current capacity: {0}", elements.Capacity);
            Console.ReadKey();
            Console.Clear();

            //testar auto grow funktionaliten.
            elements = new GenericList<int>(3);
            elements.Add(1);
            elements.Add(2);
            elements.Add(3);
            elements.Add(4);
            Console.WriteLine("Number of elements: {0}",elements.Count);
            Console.WriteLine("Current capacity: {0}", elements.Capacity);
            Console.WriteLine(elements.ToString());
            Console.ReadKey();
            Console.Clear();
            elements.Clear();

            //Testar inser och removatindex.
            elements.Insert(0, 4);
            elements.Insert(0, 3);
            elements.Insert(0, 2);
            elements.Insert(0, 1);
            elements.Insert(2, 5);
            Console.WriteLine(elements.ToString());
            Console.WriteLine("Current capacity: {0}", elements.Capacity);
            Console.ReadKey();

            elements.RemoveAtIndex(0);
            elements.RemoveAtIndex(elements.Count - 1);
            Console.WriteLine("Number of elements: {0}", elements.Count);
            Console.WriteLine("Current capacity: {0}", elements.Capacity);
            Console.WriteLine(elements.ToString());
            Console.ReadKey();
            Console.Clear();

            //Contains och indexof test.
            Console.WriteLine("Contains element 2: {0}", elements.Contains(2));
            Console.WriteLine("Index of element: {0}", elements.IndexOf(5));
            Console.ReadKey();

            Console.WriteLine("Maximum value of a single element : {0}", elements.Max());
            Console.WriteLine("Minumum value of a single element : {0}", elements.Min());
            Console.ReadKey();


        }
    }
}
