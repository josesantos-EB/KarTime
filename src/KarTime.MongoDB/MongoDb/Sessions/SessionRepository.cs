using System;
using KarTime.Sessions;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace KarTime.MongoDB.Sessions;

public class SessionRepository: MongoDbRepository<KarTimeMongoDbContext, Session, Guid>, ISessionRepository 
{
    public SessionRepository(IMongoDbContextProvider<KarTimeMongoDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}