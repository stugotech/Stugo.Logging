using System;
using System.Runtime.CompilerServices;

namespace Stugo.Logging
{
    public interface ILog
    {
#if NET45
        void Fatal(string message, [CallerMemberName] string methodName = null);
        void Error(string message, [CallerMemberName] string methodName = null);
        void Warn(string message, [CallerMemberName] string methodName = null);
        void Notice(string message, [CallerMemberName] string methodName = null);
        void Info(string message, [CallerMemberName] string methodName = null);
        void Debug(string message, [CallerMemberName] string methodName = null);
        void Trace(string message, [CallerMemberName] string methodName = null);

        void Fatal(string message, Exception exception, [CallerMemberName] string methodName = null);
        void Error(string message, Exception exception, [CallerMemberName] string methodName = null);
        void Warn(string message, Exception exception, [CallerMemberName] string methodName = null);
        void Notice(string message, Exception exception, [CallerMemberName] string methodName = null);
        void Info(string message, Exception exception, [CallerMemberName] string methodName = null);
        void Debug(string message, Exception exception, [CallerMemberName] string methodName = null);
        void Trace(string message, Exception exception, [CallerMemberName] string methodName = null);
#else
        void Fatal(string message, string methodName);
        void Error(string message, string methodName);
        void Warn(string message, string methodName);
        void Notice(string message, string methodName);
        void Info(string message, string methodName);
        void Debug(string message, string methodName);
        void Trace(string message, string methodName);

        void Fatal(string message, Exception exception, string methodName);
        void Error(string message, Exception exception, string methodName);
        void Warn(string message, Exception exception, string methodName);
        void Notice(string message, Exception exception, string methodName);
        void Info(string message, Exception exception, string methodName);
        void Debug(string message, Exception exception, string methodName);
        void Trace(string message, Exception exception, string methodName);
#endif
    }
}
