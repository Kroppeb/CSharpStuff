using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kroppeb.Additives.MoreEnumerables
{
	public class LazyEnumerable<T> : IList<T>
	{
		private List<Lazy<T>> list;
		private IEnumerable<T> Enumerable => list.Select(i => i.Value);
		private List<T> List => Enumerable.ToList();

		public T this[int index] 
		{
			get => list[index].Value;
			set => list[index] = new Lazy<T>(() => value);
		}

		public int Count => list.Count;

		public bool IsReadOnly => false;

		public void Add(T item) => list.Add(new Lazy<T>(() => item));

		public void Clear() => list.Clear();

		public bool Contains(T item) => Enumerable.Contains(item);

		public void CopyTo(T[] array, int arrayIndex) => List.CopyTo(array, arrayIndex);

		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public int IndexOf(T item) 
		{
			for (int i = 0; i < Count; i++)
			{
				if (this[i].Equals(item)) return i;
			}
			return -1;
		}

		public void Insert(int index, T item) => list.Insert(index, new Lazy<T>(() => item));

		public bool Remove(T item) {
			var p = IndexOf(item);
			if (p == -1) return false;
			list.RemoveAt(p);
			return true;
		}

		public void RemoveAt(int index) => list.RemoveAt(index);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
