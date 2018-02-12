using System;
using System.Collections.Generic;
using System.Text;

namespace Kroppeb.Algorithms.Branching
{
	public abstract class BranchHandler<T>
	{
		protected abstract Func<T, IEnumerable<T>> Brancher { get; }
		protected abstract Predicate<T> Save { get; }

		private List<T> values;

		public BranchHandler(T startValue)
		{

		}

		protected IEnumerable<T> Run(T item)
		{
			Split(item);
			return values;
		}

		public void Split(T item)
		{
			foreach (var t in Brancher(item))
			{
				if (Save(t))
					values.Add(t);
				Split(t);
			}
		}
	}
}
