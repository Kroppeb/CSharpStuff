using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Kroppeb.Additives.MoreEnumerables
{
	public class CachedEnumerableEnumerator<T> : IEnumerator<T>
	{
		private int pos = -1;
		private CachedEnumerable<T> ce;

		public CachedEnumerableEnumerator(CachedEnumerable<T> cachedEnumerable) {
			ce = cachedEnumerable;
		}

		public T Current {
			get {
				try{
					return ce.cache[pos];
				} catch (ArgumentOutOfRangeException){
					throw new InvalidOperationException();
				}
			}
		}

		object IEnumerator.Current => Current;

		public void Dispose() { }

		public bool MoveNext()
		{
			pos++;
			if(pos >= ce.cache.Count){
				return ce.CacheNext();
			}
			return true;
		}

		public void Reset() => pos = -1;
	}
}
