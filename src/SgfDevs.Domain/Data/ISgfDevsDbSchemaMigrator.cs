using System.Threading.Tasks;

namespace SgfDevs.Data
{
    public interface ISgfDevsDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
