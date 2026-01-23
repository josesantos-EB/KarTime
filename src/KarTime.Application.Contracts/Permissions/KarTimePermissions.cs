namespace KarTime.Permissions;

public static class KarTimePermissions
{
    public const string GroupName = "KarTime";

    public struct LapTime
    {
        public const string Default = GroupName + ".LapTime";
        public const string Get = Default + ".Get";
        public const string Post = Default + ".Post";
    }
    
    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}
