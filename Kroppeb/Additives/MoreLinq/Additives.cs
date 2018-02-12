using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kroppeb.Logging;
using Kroppeb.Additives.MoreEnumerables;

namespace Kroppeb.Additives.MoreLinq
{
	public static class Additives
	{
		static public ILogger Logger = ConsoleLogger.Main;

		/*
		public static TEnumerable To<TSource, TEnumerable>(this IEnumerable<TSource> source) where TEnumerable : IEnumerable<TSource>, new()
		{
			var o = new TEnumerable();
		}*/

		public static IEnumerable<TSource> Condens<TSource>(this IEnumerable<IEnumerable<TSource>> source){
			foreach (var list in source){
				foreach (var item in list){
					yield return item;
				}
			}
		}

		public static IEnumerable<TPass> PassThrough<TSource, TPass>(this IEnumerable<IEnumerable<TSource>> source, IEnumerable<TPass> seed, Func<TSource, TPass, TPass> passer)
		{
			foreach(var list in source)
			{
				seed = list.Select(i => seed.Select(s => passer(i, s))).Condens();
			}
			return seed;
		}

		public static bool IsEmpty<TSource>(this IEnumerable<TSource> source) => !source.Any();

		public static IEnumerable<TItem> PassOver<TSource, TItem>(this IEnumerable<TSource> source, TItem seed, Func<IEnumerable<TItem>,TSource,IEnumerable<TItem>> propagator, ILogger logger = null){
			IEnumerable<TItem> cur = new List<TItem> { seed };
			foreach(var s in source){
				(logger ?? Logger).Log($"(PassOver): Doing {s}", LogLevel.Debug);
				cur = propagator(cur, s);
			}
			return cur;
		}
		/*
		public static IEnumerable<T> ShallowCopy<T>(this IEnumerable<T> enumerable){
			
		}*/
		/*
		public static IEnumerable<IEnumerable<T>> CrossOver<T>(this IEnumerable<IEnumerable<T>> source){
			return source.Aggregate(new List());
		}*/

		public static IEnumerable<TSource> Add<TSource>(this IEnumerable<TSource> source , TSource item)
		{
			foreach (var l in source) yield return l;
			yield return item;
		}

		public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource item)
		{
			yield return item;
			foreach (var l in source) yield return l;
		}

		public static IEnumerable<TSource> AddRange<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> range)
		{
			foreach (var l in source) yield return l;
			foreach (var l in range) yield return l;
		}

		public static IEnumerable<IEnumerable<TSource>> Cross<TSource>(this IEnumerable<IEnumerable<TSource>> source){
			if (source.Any(a => a.IsEmpty())) return null;
			
		}

		private static IEnumerable<IEnumerable<TSource>> CrossHelp<TSource>(IEnumerator<IEnumerable<TSource>> rest){
			if (rest.MoveNext())
			{
				var cur = rest.Current.Fix();
				var nxt = CrossHelp(rest).Fix();
				foreach(var item in cur)
				{
					foreach(var list in nxt)
					{
						yield return list.Prepend(item);
					}
				}
			}

		}
	}
}
