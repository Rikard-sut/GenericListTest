using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListupg
{
    class GenericList<T>
    where T : IComparable, new()
    {
        private const int DefaultCapacity = 1;
        
        //Array av element
        private T[] elements;

        //Constructor
        public GenericList(int capacity = DefaultCapacity)
        {
            this.Count = 0;
            this.Capacity = capacity;

            this.elements = new T[capacity];
            
        }
        
        //Properties
        public int Count { get; private set; }
        public int Capacity { get; private set; }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                    throw new IndexOutOfRangeException("Index out of range.");


                    return this.elements[index];
            }
            set
            {
                this.elements[index] = value;
            }
        }

        //Metoder
        public void Add(T element) //lägg till element.
        {
            this.Count++;
            this.Resize(this.Count);
            this.elements[this.Count - 1] = element;
        }
        public void Insert(int index, T element) //Lägg till på index.
        {
            if (index < 0 || index > this.Count)
                throw new IndexOutOfRangeException("Index out of range.");
            this.Count++;
            this.Resize(this.Count);

            Array.Copy(this.elements, index, this.elements, index + 1, this.Count - index - 1); //Fråga om denna. osäker.

            this.elements[index] = element;
            
        }
        public void RemoveAtIndex(int index) //Ta bort element.
        {
            if (index < 0 || index >= this.Count)
                throw new IndexOutOfRangeException("Index not in range.");
            this.Count--;
            this.Resize(this.Count);

            Array.Copy(this.elements, index + 1, this.elements, index, this.Count - index); // SAmma här, fråga.

            this.elements[this.Count] = default(T);

        }

        
        public bool Contains(T element) //kollar och returnerar matchande värde.
        {
            return this.elements.Contains(element);
        }
        public int IndexOf(T element) //returnerar index för specifikt element.
        {
            return Array.IndexOf(this.elements, element);
        }
        public void Clear() //sätter count till 0 och skapar ny array med defaulkapacitet.
        {
            this.Count = 0;
            this.Capacity = DefaultCapacity;

            this.elements = new T[this.Capacity];
        }
        public override string ToString() //Tostring metod för klassen. 
        {
            if (this.Count == 0)
                return "Empty List";

            StringBuilder sr = new StringBuilder();
            sr.Append("Elements: ");

            for (int i = 0; i<this.Count; i++)
            {
                sr.AppendFormat("{0}", this.elements[i].ToString());

                if (i + 1 < this.Count)
                    sr.Append(", ");
            }
            return sr.ToString();
        }
        public T Min() //Kallar på minmaxfinder metoden med boolean statement för min eller max.
        {
            return this.MinMax(false);
        }
        public T Max() //Kallar på minmaxfinder metoden med boolean statement för min eller max.
        {
            return this.MinMax(true);
        }
        public T MinMax(bool value)
        {
            T best = this.elements[0]; //Assignar best till första värdet i arrayen.
            for(int i = 0; i < this.Count; i++)
            {
                if (value ? (best < (dynamic)this.elements[i]) : (best > (dynamic)this.elements[i])) //Om value är false leta efter min. om true leta efter max.
                    best = this.elements[i];
            }
            return best;
        }
        //Privat metod
        private void Resize(int capacity) //Dubblar storleken på arrayen. Denna metoden kallar jag på varje gång man gör något med arrayen.
        {
            if (capacity > this.Capacity)
            {
                this.Capacity *= 2;
                Array.Resize(ref this.elements, this.Capacity);
            }
        }






    }
}
