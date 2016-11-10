using System;
using System.IO;
using System.Reflection;

namespace Stugo.Logging
{
    public static class Logger
    {
        public const string LogConfigFileName = "logging.config";
        public const string LogFileNameFormat = "{0}.log";


        static Logger()
        {
            try
            {
                // create one log file per entry assembly to avoid problems with locking
                var entryAssembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
                Init(entryAssembly);
            }
            catch
            {
                // ignore any issues initialising logging
            }
        }


        private static void Init(Assembly entryAssembly)
        {
            var entryAssemblyInspector = new AssemblyDetailsInspector(entryAssembly);

            var logFileName = string.Format(LogFileNameFormat, entryAssembly.GetName().Name);
            var logFilePath = Path.Combine(entryAssemblyInspector.ProgramDataDirectory, logFileName);
            log4net.GlobalContext.Properties["LogFileName"] = logFilePath;

            // load config file
            var logFileConfigPath = Path.Combine(entryAssemblyInspector.ProgramDataDirectory, LogConfigFileName);
            EnsureConfigFile(logFileConfigPath);
            var configFile = new FileInfo(logFileConfigPath);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(configFile);
        }


        public static ILog GetLogger(Type t)
        {
            return new Log4NetLogWrapper(log4net.LogManager.GetLogger(t));
        }


        private static void EnsureConfigFile(string path)
        {
            if (!File.Exists(path))
            {
                // write out the model config from the assembly
                var resourceStream = typeof(Logger).Assembly
                    .GetManifestResourceStream("Stugo.Logging.logging.config");

                Stream writeStream = null;

                try
                {
                    writeStream = File.Create(path);
                    resourceStream.CopyTo(writeStream);
                }
                catch
                {
                    // delete config file if the write failed.
                    // ReSharper disable once EmptyGeneralCatchClause
                    try { File.Delete(path); } catch { }
                }
                finally
                {
                    writeStream?.Dispose();
                }
            }
        }
    }
}
