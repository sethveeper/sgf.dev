using SgfDevs.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace SgfDevs.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(SgfDevsEntityFrameworkCoreDbMigrationsModule),
        typeof(SgfDevsApplicationContractsModule)
    )]
    public class SgfDevsDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = false;
            });
        }
    }
}
