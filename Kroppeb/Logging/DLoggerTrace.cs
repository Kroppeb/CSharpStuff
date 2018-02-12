using System;
using System.Collections.Generic;
using System.Text;

namespace Kroppeb.Logging
{
	public class DLoggerTrace : IDisposable, ILogger
	{
		private string _Name;
		private string Name{
			get
			{
				return _Name ?? GetType().Name;
			}
			set
			{
				_Name = value ?? _Name;
			}
		}
		private ILogger Logger;

		public DLoggerTrace(ILogger logger, string name = null)
		{
			Logger = logger;
			Name = name;
			Logger.Log(Trace(), "Started", LogLevel.Debug);
		}

		public string Trace(){
			var log = Logger as DLoggerTrace;
			if(Logger is null){
				return $"{Logger.GetType().Name}.{Name}";
			}
			return $"{log.Trace()}.{Name}";
		}
		
		public void Dispose()
		{
			Logger.Log(Trace(), "Closed", LogLevel.Debug);
		}

		public void Log(string Message, LogLevel LogLevel = LogLevel.Log)
		{
			Logger.Log(Trace(), Message, LogLevel);
		}

		public void Log(object Source, string Message, LogLevel LogLevel = LogLevel.Log)
		{
			Logger.Log(Source, Message, LogLevel);
		}

		public void Log(string Source, string Message, LogLevel LogLevel = LogLevel.Log)
		{
			Logger.Log(Source, Message, LogLevel);
		}
	}

	public static class DLoggerExtension{
		public static DLoggerTrace Local(this ILogger logger, string name = null)
		{
			return new DLoggerTrace(logger, name);
		}
	}
}
