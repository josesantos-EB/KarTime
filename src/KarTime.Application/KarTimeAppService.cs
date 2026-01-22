using KarTime.Localization;
using Volo.Abp.Application.Services;

namespace KarTime;

/* Inherit your application services from this class.
 */
public abstract class KarTimeAppService : ApplicationService
{
    protected KarTimeAppService()
    {
        LocalizationResource = typeof(KarTimeResource);
    }
}
