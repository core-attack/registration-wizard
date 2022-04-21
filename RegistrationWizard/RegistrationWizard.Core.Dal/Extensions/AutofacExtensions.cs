namespace RegistrationWizard.Core.Dal.Extensions
{
    using Autofac;
    using Autofac.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;

    public static class AutofacExtensions
    {
        public static IRegistrationBuilder<TOptions, SimpleActivatorData, SingleRegistrationStyle>
            RegisterConfiguration<TOptions>(
                this ContainerBuilder builder,
                string sectionName)
            where TOptions : class, new()
        {
            builder.Register(
                    c =>
                        new ConfigurationChangeTokenSource<TOptions>(
                            Options.DefaultName,
                            c.Resolve<IConfiguration>().GetSection(sectionName)))
                .As<IOptionsChangeTokenSource<TOptions>>()
                .SingleInstance();

            builder.Register(
                    c =>
                        new NamedConfigureFromConfigurationOptions<TOptions>(
                            Options.DefaultName,
                            c.Resolve<IConfiguration>().GetSection(sectionName)))
                .As<IConfigureOptions<TOptions>>()
                .SingleInstance();

            return builder.Register(c => c.Resolve<IOptions<TOptions>>().Value)
                .As<TOptions>()
                .SingleInstance();
        }
    }
}