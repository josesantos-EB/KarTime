using Volo.Abp.Settings;

namespace KarTime.Settings;

public class KarTimeSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(KarTimeSettings.MySetting1));
    }
}
