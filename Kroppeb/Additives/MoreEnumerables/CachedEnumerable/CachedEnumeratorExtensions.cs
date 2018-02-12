using System;
using System.Collections.Generic;
using System.Text;

namespace Kroppeb.Additives.MoreEnumerables
{
    public static class CachedEnumeratorExtensions
    {
		public static CachedEnumerable<T> Fix<T>(this IEnumerable<T> source)
		{
			var s = source as CachedEnumerable<T>;
			if (s is null)
			{
				return new CachedEnumerable<T>(source);
			}
			else
			{
				return s;
			}

		}
	}
}
