using System.Collections;
using System.Collections.Generic;

namespace Charpoos
{
    public class Yield<T> : IEnumerable<T>
    {
        private readonly T _item;

        public Yield(T item)
        {
            _item = item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return _item;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}