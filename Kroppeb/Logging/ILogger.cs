using System;
using System.Collections.Generic;
using System.Text;

namespace Kroppeb.Logging
{
    public interface ILogger
    {
		void Log(string Message, LogLevel LogLevel = LogLevel.Log);
		void Log(object Source, string Message, LogLevel LogLevel = LogLevel.Log);
		void Log(string Source, string Message, LogLevel LogLevel = LogLevel.Log);
	}
}
