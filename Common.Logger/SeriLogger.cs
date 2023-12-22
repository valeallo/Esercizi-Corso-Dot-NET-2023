using System;
using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.Extensions.Logging;
using Serilog.Events;


namespace Common.Logger
{
    public class SeriLogger
    {

        public static Action<HostBuilderContext, LoggerConfiguration> Configure = (context, configuration) =>
            {
                configuration
                    .Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .WriteTo.Debug()
                    .WriteTo.Console()
                    .Enrich.WithProperty("Environment", HostingEnvironment.EnvironmentName)
                    .Enrich.WithProperty("Application", HostingEnvironment.ApplicationName)
                    .ReadFrom.Configuration(context.Configuration);
                

            };
    }
}
