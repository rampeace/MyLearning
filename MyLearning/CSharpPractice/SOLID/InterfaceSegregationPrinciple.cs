using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.SOLID
{
    internal class InterfaceSegregationPrinciple
    {
        /*
         * The Interface Segregation Principle (ISP) states that clients should not be forced to depend on interfaces they do not use.

         * */

        // Problem
        public interface IReadonlyCollection<T>
        {
            void Add(T item);
            void Remove(int index);
        }

        public class MyReadonlyCollection<T> : IReadonlyCollection<T>
        {
            public void Add(T item)
            {
                throw new InvalidOperationException();
            }

            public void Remove(int index)
            {
                throw new InvalidOperationException();
            }
        }

        // Fix
        public interface IReadonlyCollection2<T>
        {
            T Get(int index);
            int Count { get; }
        }

        public interface IMutableCollection<T>
        {
            void Add(T item);
            void Remove(int index);
        }

        public class MyReadonlyCollection2<T> : IReadonlyCollection2<T>
        {
            private readonly List<T> _items = new();

            public T Get(int index) => _items[index];
            public int Count => _items.Count;
        }
    }
}
