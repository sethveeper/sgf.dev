using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SgfDevs.Data;
using Serilog;
using Volo.Abp;

namespace SgfDevs.DbMigrator
{
    public class DbMigratorHostedService : IHostedService
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        public DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime)
        {
            _hostApplicationLifetime = hostApplicationLifetime;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var application = AbpApplicationFactory.Create<SgfDevsDbMigratorModule>(options =>
                {
                    options.UseAutofac();
                    options.Services.AddLogging(c => c.AddSerilog());
                }))
                {
                    application.Initialize();

                    await application
                        .ServiceProvider
                        .GetRequiredService<SgfDevsDbMigrationService>()
                        .MigrateAsync();

                    application.Shutdown();

                    _hostApplicationLifetime.StopApplication();
                }

        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
