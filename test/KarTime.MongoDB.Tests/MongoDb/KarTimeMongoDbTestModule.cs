using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace KarTime.MongoDB;

[DependsOn(
    typeof(KarTimeApplicationTestModule),
    typeof(KarTimeMongoDbModule)
)]
public class KarTimeMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = KarTimeMongoDbFixture.GetRandomConnectionString();
        });
    }
}
