using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SgfDevs.Data
{
    /* This is used if database provider does't define
     * ISgfDevsDbSchemaMigrator implementation.
     */
    public class NullSgfDevsDbSchemaMigrator : ISgfDevsDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}
