using KarTime.MongoDB;
using KarTime.Sessions;
using Xunit;

namespace KarTime.MongoDb.Applications;

[Collection(KarTimeTestConsts.CollectionDefinitionName)]
public class MongoDBSessionAppServiceTests: SessionAppServiceTest<KarTimeMongoDbTestModule>
{
    
}