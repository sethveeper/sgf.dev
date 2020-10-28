using SgfDevs.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SgfDevs
{
    [DependsOn(
        typeof(SgfDevsEntityFrameworkCoreTestModule)
        )]
    public class SgfDevsDomainTestModule : AbpModule
    {

    }
}
