using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace KarTime.Data;

/* This is used if database provider does't define
 * IKarTimeDbSchemaMigrator implementation.
 */
public class NullKarTimeDbSchemaMigrator : IKarTimeDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
