using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using UsedTokenCollector;

[assembly: FunctionsStartup(typeof(Startup))]

namespace UsedTokenCollector
{
    public class Startup : FunctionsStartup
    {
        public Startup()
        {
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            //var executionContextOptions = builder.Services.BuildServiceProvider()
            //    .GetService<IOptions<ExecutionContextOptions>>()
            //    .Value;

            //var appDirectory = executionContextOptions.AppDirectory;

            //var conf = new ConfigurationBuilder()
            //    .SetBasePath(appDirectory)
            //    .AddJsonFile("appSettings.json", true, true)
            //    .AddJsonFile("local.settings.json", true, true)
            //    .Build();

            //var connectionString = conf.GetConnectionString("IntelligentCookingDb");
            builder.Services.AddDataLayerDependecies(
                "Server = tcp:intelligentcookingsqlserver.database.windows.net, 1433; Initial Catalog = IntelligentCookingDB; Persist Security Info = False; User ID = ungidrid; Password = LeoBit123; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        }
    }
}
