using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SgfDevs.Data;
using Volo.Abp.DependencyInjection;

namespace SgfDevs.EntityFrameworkCore
{
    public class EntityFrameworkCoreSgfDevsDbSchemaMigrator
        : ISgfDevsDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreSgfDevsDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the SgfDevsMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<SgfDevsMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
