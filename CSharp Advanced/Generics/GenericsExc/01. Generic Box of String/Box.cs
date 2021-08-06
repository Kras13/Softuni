using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T> : IComparable<T> where T : IComparable<T>
    {
        public T Element { get; }

        public List<T> Elements { get; }

        public Box(T element)
        {
            this.Element = element;
        }

        public Box(List<T> elementsList)
        {
            this.Elements = elementsList;
        }

        public void Swap(List<T> elements, int indexOne, int indexTwo)
        {
            T firstEl = elements[indexOne];
            elements[indexOne] = elements[indexTwo];
            elements[indexTwo] = firstEl;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            //return $"{typeof(T)}: {Element}";
            foreach (var element in Elements)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }

            return sb.ToString().TrimEnd();
        }

        public int CompareTo(T other) => Element.CompareTo(other);

        public int CountOfGreaterElements<T>(List<T> list, T readLine) where T : IComparable
        {
            return list.Count(word => word.CompareTo(readLine) > 0);
        }
    }
}
