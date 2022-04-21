namespace RegistrationWizard.Core.Logging
{
    using System;

    public interface ILogger
    {
        void LogDebug(string messageTemplate, params object[] propertyValues);

        void LogException(Exception exception, string messageTemplate, params object[] propertyValues);
    }
}
