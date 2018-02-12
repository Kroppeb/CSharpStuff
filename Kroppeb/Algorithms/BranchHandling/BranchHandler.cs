using System;
using System.Collections.Generic;
using System.Text;

namespace Kroppeb.Algorithms.BranchHandling
{
	public class BranchHandler<T> 
	{
		public Branch<T> MainBranch { get; private set; }
		public T Item { get; private set; }

		public BranchHandler(T item)
		{
			Item = item;
		}


		public IEnumerable<T> Run()  => 
			(MainBranch = MainBranch ?? new Branch<T>(Item, this)).Run();

		public IEnumerable<Branch<T>> SplitOn(T Item)
		{

		}
	}
}
