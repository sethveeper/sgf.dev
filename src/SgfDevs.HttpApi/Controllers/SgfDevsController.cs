using SgfDevs.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SgfDevs.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class SgfDevsController : AbpController
    {
        protected SgfDevsController()
        {
            LocalizationResource = typeof(SgfDevsResource);
        }
    }
}
