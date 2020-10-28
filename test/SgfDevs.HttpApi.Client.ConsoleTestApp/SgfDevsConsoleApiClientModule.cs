using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace SgfDevs.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(SgfDevsHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class SgfDevsConsoleApiClientModule : AbpModule
    {
        
    }
}
