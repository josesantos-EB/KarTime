using Volo.Abp.Settings;

namespace KarTime.Settings;

public class KarTimeSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(
            new SettingDefinition("Track.Spa", "500"),
            new SettingDefinition("Track.Interlagos", "350"),
            new SettingDefinition("Track.Suzuka", "450")
        );

        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(KarTimeSettings.MySetting1));
    }
}
