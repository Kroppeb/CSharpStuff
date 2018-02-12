using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kroppeb.Copyable
{
    public static class DeepCopyable
    {
		public static IEnumerable<TSource> DeepCopy<TSource>(this IEnumerable<TSource> source) where TSource : IDeepCopyable<TSource>
		{
			return source.Select(s => s.DeepCopy());
		}
	}
}
