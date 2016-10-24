using System;
using System.Runtime.CompilerServices;

namespace Stugo.Logging
{
    public interface ILog
    {
        void Fatal(string message, Exception exception = null, [CallerMemberName] string methodName = null);
        void Error(string message, Exception exception = null, [CallerMemberName] string methodName = null);
        void Warn(string message, Exception exception = null, [CallerMemberName] string methodName = null);
        void Notice(string message, Exception exception = null, [CallerMemberName] string methodName = null);
        void Info(string message, Exception exception = null, [CallerMemberName] string methodName = null);
        void Debug(string message, Exception exception = null, [CallerMemberName] string methodName = null);
        void Trace(string message, Exception exception = null, [CallerMemberName] string methodName = null);
    }
}
