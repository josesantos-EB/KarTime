using Microsoft.Extensions.Localization;
using KarTime.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace KarTime;

[Dependency(ReplaceServices = true)]
public class KarTimeBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<KarTimeResource> _localizer;

    public KarTimeBrandingProvider(IStringLocalizer<KarTimeResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
