using Volo.Abp.Modularity;

namespace KarTime;

/* Inherit from this class for your domain layer tests. */
public abstract class KarTimeDomainTestBase<TStartupModule> : KarTimeTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
