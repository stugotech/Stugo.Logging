using System;
using System.Runtime.CompilerServices;

namespace Stugo.Logging
{
    class Log4NetLogWrapper : ILog
    {
        private const string MethodNamePropertyName = "staticMethodName";
        private static readonly Type ThisDeclaringType = typeof(Log4NetLogWrapper);
        private readonly log4net.ILog wrapped;


        internal Log4NetLogWrapper(log4net.ILog wrapped)
        {
            this.wrapped = wrapped;
        }



        public void Debug(string message, Exception exception = null, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Debug, message, exception, methodName);
        }

        public void Error(string message, Exception exception = null, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Error, message, exception, methodName);
        }

        public void Fatal(string message, Exception exception = null, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Fatal, message, exception, methodName);
        }

        public void Notice(string message, Exception exception = null, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Notice, message, exception, methodName);
        }

        public void Info(string message, Exception exception = null, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Info, message, exception, methodName);
        }

        public void Warn(string message, Exception exception = null, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Warn, message, exception, methodName);
        }

        public void Trace(string message, Exception exception = null, [CallerMemberName] string methodName = null)
        {
            Log(log4net.Core.Level.Trace, message, exception, methodName);
        }


        private void Log(log4net.Core.Level level, string message, Exception exception, string methodName)
        {
            var loggingEvent = new log4net.Core.LoggingEvent(
                ThisDeclaringType, wrapped.Logger.Repository, wrapped.Logger.Name,
                level, message, exception
            );
            loggingEvent.Properties[MethodNamePropertyName] = methodName;
            wrapped.Logger.Log(loggingEvent);
        }
    }
}
