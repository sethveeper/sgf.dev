using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SgfDevs.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class SgfDevsMigrationsDbContextFactory : IDesignTimeDbContextFactory<SgfDevsMigrationsDbContext>
    {
        public SgfDevsMigrationsDbContext CreateDbContext(string[] args)
        {
            SgfDevsEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<SgfDevsMigrationsDbContext>()
                .UseNpgsql(configuration.GetConnectionString("Default"));

            return new SgfDevsMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SgfDevs.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
