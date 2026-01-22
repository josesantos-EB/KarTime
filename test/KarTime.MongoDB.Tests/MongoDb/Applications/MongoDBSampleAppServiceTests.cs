using KarTime.MongoDB;
using KarTime.Samples;
using Xunit;

namespace KarTime.MongoDb.Applications;

[Collection(KarTimeTestConsts.CollectionDefinitionName)]
public class MongoDBSampleAppServiceTests : SampleAppServiceTests<KarTimeMongoDbTestModule>
{

}
