using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicArrayImpl
{
    public class MyList<T> : IEnumerable, IEnumerator
    {
        private T[] array;

        public int Count { get; private set; }

        private int position = -1;

        public MyList()
        {
            array = new T[4];
            Count = 0;
        }

        public MyList(IEnumerable<T> input)
        {
            int count = input.Count();
            array = new T[input.Count()];
            int counter = 0;

            foreach (var item in input)
            {
                array[counter++] = item;
                this.Count++;
            }
        }

        public void AddElement(T element)
        {
            if (element == null)
            {
                return;
            }

            if (Count >= array.Length)
            {
                T[] newArray = new T[array.Length * 2];

                for (int i = 0; i < array.Length; i++)
                {
                    newArray[i] = array[i];
                }

                newArray[Count++] = element;
                array = newArray;
            }
            else
            {
                array[Count++] = element;
            }
        }

        public T this[int index]
        {
            get
            {
                return this.array[index];
            }
            set
            {
                this.array[index] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            position++;
            return (position < array.Length);
        }

        public void Reset()
        {
            position = 0;
        }

        public object Current
        {
            get { return array[position]; }
        }

        public T[] ToArray()
        {
            T[] result = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                result[i] = array[i];
            }

            return result;
        }
    }
}
