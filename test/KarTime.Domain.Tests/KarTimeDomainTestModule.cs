using Volo.Abp.Modularity;

namespace KarTime;

[DependsOn(
    typeof(KarTimeDomainModule),
    typeof(KarTimeTestBaseModule)
)]
public class KarTimeDomainTestModule : AbpModule
{

}
