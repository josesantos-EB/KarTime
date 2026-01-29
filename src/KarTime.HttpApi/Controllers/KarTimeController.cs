using KarTime.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace KarTime.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class KarTimeController : AbpControllerBase
{
    protected KarTimeController()
    {
        LocalizationResource = typeof(KarTimeResource);
    }
}
