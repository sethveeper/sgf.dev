using Volo.Abp.Modularity;

namespace SgfDevs
{
    [DependsOn(
        typeof(SgfDevsApplicationModule),
        typeof(SgfDevsDomainTestModule)
        )]
    public class SgfDevsApplicationTestModule : AbpModule
    {

    }
}
