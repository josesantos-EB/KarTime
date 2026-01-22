using System.Threading.Tasks;

namespace KarTime.Data;

public interface IKarTimeDbSchemaMigrator
{
    Task MigrateAsync();
}
