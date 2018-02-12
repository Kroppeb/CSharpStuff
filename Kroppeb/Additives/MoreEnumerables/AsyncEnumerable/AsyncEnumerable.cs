using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kroppeb.Additives.MoreEnumerables
{
	public class AsyncEnumerable<T>
	{
		private CachedEnumerable<Task<T>> items;
		public int KeepLoading { get; set; }
		private int Loading { get; set; }

		public AsyncEnumerable(IEnumerable<Task<T>> enumerable)
		{
			items = new CachedEnumerable<Task<T>>(enumerable);
		}
	}
}
