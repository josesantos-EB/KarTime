using KarTime.Sessions;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;
using MongoDB.Driver;

namespace KarTime.MongoDB;

[ConnectionStringName("Default")]
public class KarTimeMongoDbContext : AbpMongoDbContext
{

    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */
    public IMongoCollection<Session> Sessions => Collection<Session>();

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.Entity<Session>();
        //builder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});
    }
}
