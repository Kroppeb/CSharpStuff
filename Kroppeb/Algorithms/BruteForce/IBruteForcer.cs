using System;
using System.Collections.Generic;
using System.Text;

namespace Kroppeb.Algorithms.BruteForce
{
    public interface IBruteForcer<TBase> where TBase : struct,IBruteForceState
    {
		TBase StartingValue { get; }
		Predicate<TBase> Save { get; }
		Predicate<TBase> Stop { get; }
		IEnumerable<TBase> Results { get; }
    }
}
