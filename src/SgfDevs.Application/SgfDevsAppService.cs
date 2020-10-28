using SgfDevs.Localization;
using Volo.Abp.Application.Services;

namespace SgfDevs
{
    /* Inherit your application services from this class.
     */
    public abstract class SgfDevsAppService : ApplicationService
    {
        protected SgfDevsAppService()
        {
            LocalizationResource = typeof(SgfDevsResource);
        }
    }
}
