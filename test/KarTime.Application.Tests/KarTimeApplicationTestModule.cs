using Volo.Abp.Modularity;

namespace KarTime;

[DependsOn(
    typeof(KarTimeApplicationModule),
    typeof(KarTimeDomainTestModule)
)]
public class KarTimeApplicationTestModule : AbpModule
{

}
