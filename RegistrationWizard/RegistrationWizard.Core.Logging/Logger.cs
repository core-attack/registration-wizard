namespace RegistrationWizard.Core.Logging
{
    using System;
    using Serilog.Events;

    public class Logger : ILogger
    {
        public const string LogTypeIndexName = "LogType";

        public const string ApplicationLogTypeName = "Application";

        private readonly Serilog.ILogger _appLogger;

        public Logger(Serilog.ILogger logger)
        {
            _appLogger = logger;
        }

        public void LogDebug(string messageTemplate, params object[] propertyValues)
        {
            WriteAppLog(LogEventLevel.Debug, null, messageTemplate, propertyValues);
        }

        public void LogException(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            WriteAppLog(LogEventLevel.Error, exception, messageTemplate, propertyValues);
        }

        private void WriteAppLog(LogEventLevel level, Exception? exception, string messageTemplate, params object[] propertyValues)
        {
            _appLogger.Write(level, exception, messageTemplate, propertyValues);
        }
    }
}
