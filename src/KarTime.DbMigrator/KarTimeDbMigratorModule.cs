using KarTime.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace KarTime.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(KarTimeMongoDbModule),
    typeof(KarTimeApplicationContractsModule)
)]
public class KarTimeDbMigratorModule : AbpModule
{
}
