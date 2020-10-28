using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace SgfDevs.EntityFrameworkCore
{
    [DependsOn(
        typeof(SgfDevsEntityFrameworkCoreModule)
    )]
    public class SgfDevsEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<SgfDevsMigrationsDbContext>();
        }
    }
}
