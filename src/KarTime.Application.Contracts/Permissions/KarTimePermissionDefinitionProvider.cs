using KarTime.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace KarTime.Permissions;

public class KarTimePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(KarTimePermissions.GroupName);

        myGroup.AddPermission(KarTimePermissions.LapTime.Default);
        myGroup.AddPermission(KarTimePermissions.LapTime.Post);
        myGroup.AddPermission(KarTimePermissions.LapTime.Get);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(KarTimePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<KarTimeResource>(name);
    }
}
