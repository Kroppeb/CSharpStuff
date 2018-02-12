using System;
using System.Collections.Generic;
using System.Text;

namespace Kroppeb.Logging
{
    public class Logger : ILogger
    {
		public static Logger MainLogger = new Logger();

		
		public event EventHandler<LoggerMessageArgs> Message;

		public Logger() { }

		protected virtual void OnMessage(LoggerMessageArgs e)
		{
			Message?.Invoke(this, e);
		}

		public void Log(string Message, LogLevel LogLevel = LogLevel.Log)
			=> OnMessage(new LoggerMessageArgs { Message = Message, LogLevel = LogLevel });
		

		public void Log(object Source, string Message, LogLevel LogLevel = LogLevel.Log)
			=> Log(Source.ToString(), Message, LogLevel);

		public void Log(string Source, string Message, LogLevel LogLevel = LogLevel.Log)
			=> OnMessage(new LoggerMessageArgs { Source = Source, Message = Message, LogLevel = LogLevel });
	}

	public class LoggerMessageArgs : EventArgs
	{
		public LogLevel LogLevel;
		public string Message;
		public string Source;
	}

	public enum LogLevel
	{
		Debug,
		Log,
		Warn,
		Error
	}
}
