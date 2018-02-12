using System;
using System.Collections.Generic;
using System.Text;

namespace Kroppeb.Logging
{
    class ConsoleLogger : ILogger
    {
		static public ConsoleLogger Main = new ConsoleLogger(Logger.MainLogger);
		private Logger logger;

		public LogLevel LogLevel = LogLevel.Log;

		public ConsoleLogger() {
			logger = new Logger();
			logger.Message += Log;
		}

		public ConsoleLogger(Logger logger){
			this.logger = logger;
			logger.Message += Log;
		}

		private void Log(object sender, LoggerMessageArgs a){
			if (a.LogLevel >= LogLevel){
				ConsoleColor prev = Console.ForegroundColor;
				Console.ForegroundColor = ColorFromLevel(a.LogLevel);
				if (a.Source is null)
				{
					Console.WriteLine(a.Message);
				} else {
					Console.WriteLine($"{a.Source}: {a.Message}");
				}
				Console.ForegroundColor = prev;
			}
		}

		static private ConsoleColor ColorFromLevel(LogLevel level){
			switch(level){
				case LogLevel.Debug:
					return ConsoleColor.Gray;
				case LogLevel.Log:
					return ConsoleColor.White;
				case LogLevel.Warn:
					return ConsoleColor.Yellow;
				case LogLevel.Error:
					return ConsoleColor.Red;
			}
			return ConsoleColor.White;
		}

		public void Log(string Message, LogLevel LogLevel = LogLevel.Log)
		{
			logger.Log(Message, LogLevel);
		}

		public void Log(object Source, string Message, LogLevel LogLevel = LogLevel.Log)
		{
			logger.Log(Source, Message, LogLevel);
		}

		public void Log(string Source, string Message, LogLevel LogLevel = LogLevel.Log)
		{
			logger.Log(Source, Message, LogLevel);
		}
	}
}
