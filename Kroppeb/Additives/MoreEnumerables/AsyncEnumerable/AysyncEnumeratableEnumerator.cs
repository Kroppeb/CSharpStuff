using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Kroppeb.Additives.MoreEnumerables
{
	public class AsyncEnumerableEnumerator<T> 
	{
		private int pos = -1;
		private AsyncEnumerable<T> ce;

		public AsyncEnumerableEnumerator(AsyncEnumerable<T> cachedEnumerable) {
			ce = cachedEnumerable;
		}

		public void Dispose() { }
		
	}
}
