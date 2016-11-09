using System;
using System.Runtime.CompilerServices;

namespace Stugo.Logging
{
    class Log4NetLogWrapper : ILog
    {
        private const string MethodNamePropertyName = "staticMethodName";
        private static readonly Type thisDeclaringType = typeof(Log4NetLogWrapper);
        private readonly log4net.ILog wrapped;


        internal Log4NetLogWrapper(log4net.ILog wrapped)
        {
            this.wrapped = wrapped;
        }


#if NET45
        public void Debug(string message, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Debug, message, null, methodName);
        }

        public void Error(string message, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Error, message, null, methodName);
        }

        public void Fatal(string message, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Fatal, message, null, methodName);
        }

        public void Notice(string message, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Notice, message, null, methodName);
        }

        public void Info(string message, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Info, message, null, methodName);
        }

        public void Warn(string message, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Warn, message, null, methodName);
        }

        public void Trace(string message, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Trace, message, null, methodName);
        }

        public void Debug(string message, Exception exception, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Debug, message, exception, methodName);
        }

        public void Error(string message, Exception exception, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Error, message, exception, methodName);
        }

        public void Fatal(string message, Exception exception, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Fatal, message, exception, methodName);
        }

        public void Notice(string message, Exception exception, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Notice, message, exception, methodName);
        }

        public void Info(string message, Exception exception, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Info, message, exception, methodName);
        }

        public void Warn(string message, Exception exception, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Warn, message, exception, methodName);
        }

        public void Trace(string message, Exception exception, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Trace, message, exception, methodName);
        }
#else
        public void Fatal(string message, string methodName)
        {
            Log(log4net.Core.Level.Fatal, message, null, methodName);
        }

        public void Error(string message, string methodName)
        {
            Log(log4net.Core.Level.Error, message, null, methodName);
        }

        public void Warn(string message, string methodName)
        {
            Log(log4net.Core.Level.Warn, message, null, methodName);
        }

        public void Notice(string message, string methodName)
        {
            Log(log4net.Core.Level.Notice, message, null, methodName);
        }

        public void Info(string message, string methodName)
        {
            Log(log4net.Core.Level.Info, message, null, methodName);
        }

        public void Debug(string message, string methodName)
        {
            Log(log4net.Core.Level.Debug, message, null, methodName);
        }

        public void Trace(string message, string methodName)
        {
            Log(log4net.Core.Level.Trace, message, null, methodName);
        }

        public void Fatal(string message, Exception exception, string methodName)
        {
            Log(log4net.Core.Level.Fatal, message, exception, methodName);
        }

        public void Error(string message, Exception exception, string methodName)
        {
            Log(log4net.Core.Level.Error, message, exception, methodName);
        }

        public void Warn(string message, Exception exception, string methodName)
        {
            Log(log4net.Core.Level.Warn, message, exception, methodName);
        }

        public void Notice(string message, Exception exception, string methodName)
        {
            Log(log4net.Core.Level.Notice, message, exception, methodName);
        }

        public void Info(string message, Exception exception, string methodName)
        {
            Log(log4net.Core.Level.Info, message, exception, methodName);
        }

        public void Debug(string message, Exception exception, string methodName)
        {
            Log(log4net.Core.Level.Debug, message, exception, methodName);
        }

        public void Trace(string message, Exception exception, string methodName)
        {
            Log(log4net.Core.Level.Trace, message, exception, methodName);
        }
#endif


        private void Log(log4net.Core.Level level, string message, Exception exception, string methodName)
        {
            var loggingEvent = new log4net.Core.LoggingEvent(
                thisDeclaringType, wrapped.Logger.Repository, wrapped.Logger.Name,
                level, message, exception
            );
            loggingEvent.Properties[MethodNamePropertyName] = methodName;
            wrapped.Logger.Log(loggingEvent);
        }
    }
}
