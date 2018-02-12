using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Kroppeb.Additives.MoreEnumerables;

namespace Kroppeb.Algorithms.BranchHandling
{
	public class Branch<T>
	{
		private CachedEnumerable<T> values;
		private BranchHandler<T> handler;
		private bool ItemSet = false;
		private T item;

		public virtual IEnumerable<Branch<T>> BranchList => handler.SplitOn(Item);
		public BranchHandler<T> Handler
		{
			get => handler;
			set => handler = handler ?? value;
		}

		public T Item
		{
			get => item;
			set
			{
				if (!ItemSet)
				{
					item = value;
					ItemSet = true;
				}
			}
		}

		public Branch() 
		{
		}

		public Branch(T item, BranchHandler<T> handler)
		{
			this.item = item;
			this.handler = handler;
		}

		public virtual IEnumerable<T> Run() => (values = values ?? BranchList.SelectMany(b => b.Run()).Fix());
	}
}
