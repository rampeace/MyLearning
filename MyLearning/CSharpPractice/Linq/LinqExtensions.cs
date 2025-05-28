using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Linq
{
    public static class LinqExtensions
    {
        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            foreach (var item in source)
            {
                if (predicate(item)) 
                    yield return item;
            }
        }

        /// <summary>
        /// Returns the first index of the matching element. Returns -1 if not match is found.
        /// </summary>
        /// <typeparam name="T">The type of the source element</typeparam>
        /// <param name="source">The source element</param>
        /// <param name="predicate">The predicate which checks for a match</param>
        /// <returns>Returns the index if found. -1 if not found.</returns>
        public static int IndexOf<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            int index = 0;
            foreach (var item in source)
            {
                if (predicate(item))
                    return index;
                index++;
            }
            return -1;
        }
        
        public static int IndexOf<T>(this IEnumerable<T> source, T element)
        {
            int index = 0;

            foreach (var item in source)
            {
                if (element.Equals(item))
                    return index;

                index++;
            }
            return -1;
        }

        public static IEnumerable<int> IndexOfAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            int index = 0;

            foreach (var item in source)
            {
                if (predicate(item))
                    yield return index;

                index++;
            }
        }

        public static TSeed MyAggregate<TSource, TSeed>(this IEnumerable<TSource> source, TSeed seed, Func<TSeed, TSource, TSeed> resultSelector)
        {
            TSeed acc = seed;
            
            foreach (var item in source)
            {
                acc = resultSelector(acc, item);
            }
            return acc;
        }

        public static TSource MyFirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            var e = source.GetEnumerator();

            if (!e.MoveNext())
                return default;

            return e.Current;
        }

        public static IEnumerable<T> MyTakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in source)
            {
                if (!predicate(item))
                    yield break;

                yield return item;
            }
        }

        public static IEnumerable<T> MySkipWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) 
                throw new ArgumentNullException(nameof (source));
            if (predicate  == null) 
                throw new ArgumentNullException (nameof(predicate));

            bool skip = true;
            foreach (var item in source)
            {
                skip = skip ? predicate(item) : false;

                if (!skip)
                {
                    yield return item;
                }
            }
        }

        public static void ForEach<T>(this IEnumerable<T> source,  Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}
