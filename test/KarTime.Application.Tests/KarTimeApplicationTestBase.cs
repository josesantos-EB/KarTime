using Volo.Abp.Modularity;

namespace KarTime;

public abstract class KarTimeApplicationTestBase<TStartupModule> : KarTimeTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
