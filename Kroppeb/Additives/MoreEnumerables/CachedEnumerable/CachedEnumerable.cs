using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kroppeb.Additives.MoreEnumerables
{
	public class CachedEnumerable<T> : IEnumerable<T>
	{
		internal List<T> cache;
		private IEnumerator<T> rest;
		private bool end = true;

		public CachedEnumerable(IEnumerable<T> enumerable){
			cache = new List<T>();
			rest = enumerable.GetEnumerator();
		}

		public bool CacheNext(){
			if (!end) return false;
			end = rest.MoveNext();
			if (!end) return false;
			cache.Add(rest.Current);
			return true;
		}

		public IEnumerator<T> GetEnumerator() => new CachedEnumerableEnumerator<T>(this);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
