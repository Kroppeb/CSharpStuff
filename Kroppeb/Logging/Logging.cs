using System;
using System.Collections.Generic;
using System.Text;

namespace Kroppeb.Logging
{
	public interface ILoggable
	{

	}

	public static class Logging
	{
		public static void UsingLogger<T>(this T self, ILogger logger, Action<T> action)
		{
			using (logger.Local())
			{
				action(self);
			}
		}

		public static void UsingLogger<T>(this T self, ILogger logger, string name, Action<T> action)
		{
			using (logger.Local(name))
			{
				action(self);
			}
		}

		public static TR UsingLogger<T,TR>(this T self, ILogger logger, Func<T, TR> func)
		{
			TR ret;
			using (logger.Local())
			{
				ret = func(self);
			}
			return ret;
		}

		public static TR UsingLogger<T, TR>(this T self, ILogger logger, string name, Func<T, TR> func)
		{
			TR ret;
			using (logger.Local(name))
			{
				ret = func(self);
			}
			return ret;
		}
	}
}
