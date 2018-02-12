using System;
using System.Collections.Generic;
using System.Text;

using Kroppeb.Algorithms.Branching;

namespace Kroppeb.Algorithms.BruteForce
{
	public class StandardBruteForce<TBase> : IBruteForcer<TBase> where TBase:struct,IBruteForceState
	{
		private TBase startingValue;
		private Predicate<TBase> save, stop;
		private Func<TBase, IEnumerable<TBase>> branches;

		public TBase StartingValue => startingValue;
		public Predicate<TBase> Stop => stop;
		public Predicate<TBase> Save => save;
		public IEnumerable<TBase> Results => throw new NotImplementedException();

		public StandardBruteForce(TBase start, Predicate<TBase> save, Predicate<TBase> stop, Func<TBase, IEnumerable<TBase>> branching)
		{
			startingValue = start;
			this.save = save;
			this.stop = stop;
			branches = branching;
		}

		public TBranch Start<TBranch>() where TBranch : IBranchHandler,new()
		{
			TBranch handler = new TBranch()
			{

			}
		}
	}
}
