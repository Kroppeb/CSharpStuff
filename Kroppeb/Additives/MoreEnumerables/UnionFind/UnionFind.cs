using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Kroppeb.Additives.HandyExtensions;

namespace Kroppeb.Additives.MoreEnumerables
{
    class UnionFind<T> : IEnumerable
    {
		internal class Item : IComparable<Item>, IComparable<T>
		{
			public int id;
			public T item;
			public int parent;

			public int CompareTo(Item other) => item.CompareHashTo(other.item);

			public int CompareTo(T other) => item.CompareHashTo(other);
		}

		private HashSet<T> all;
		private List<Item> list;

		public UnionFind()
		{
			all = new HashSet<T>();
			list = new List<Item>();
		}

		public void Add(T item)
		{
			if (all.Contains(item)) return;
			all.Add(item);
			list.Add(new Item { id = list.Count, item = item, parent = list.Count });
		}

		public int GetParent() { }

		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
