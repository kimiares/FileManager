using FileManager.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TResult> ZipAll<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, 
            IEnumerable<TSecond> second, 
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            if (first == null) throw new CollectionNullException("First collection is Empty");
            if (second == null) throw new CollectionNullException("Second collection is Empty");
            if (resultSelector == null) throw new CollectionNullException("Collection is Empty");
            return ZipAllIterator(first, second, resultSelector);
        }



        static IEnumerable<TResult> ZipAllIterator<TFirst, TSecond, TResult>(IEnumerable<TFirst> first,
            IEnumerable<TSecond> second, 
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            using (IEnumerator<TFirst> e1 = first.GetEnumerator())
            using (IEnumerator<TSecond> e2 = second.GetEnumerator())
                
                
                while (e1.MoveNext() | e2.MoveNext())
                    yield return resultSelector(e1.Current, e2.Current);
        }


     



        public static IEnumerable<T> Each<T>(this IEnumerable<T> data, Action<T> func)
        {
            foreach (var map in data)
            {
                func(map);
                yield return map;
                
            }
        }
    }
}
