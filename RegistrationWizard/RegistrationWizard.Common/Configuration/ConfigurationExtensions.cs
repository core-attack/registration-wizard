using Microsoft.Extensions.Configuration;
using System;

namespace RegistrationWizard.Common.Configuration
{
    public static class ConfigurationExtensions
    {
        public static T? Get<T>(this IConfiguration configuration, string section) =>
            configuration.GetSection(section).Get<T>();

        public static T GetRequired<T>(this IConfiguration configuration, string section)
        {
            var result = configuration.Get<T>(section);

            if (result == null)
            {
                throw new InvalidOperationException($"Configuration section {section} is required");
            }

            return result;
        }
    }
}
