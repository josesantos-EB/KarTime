using KarTime.Samples;
using Xunit;

namespace KarTime.MongoDB.Domains;

[Collection(KarTimeTestConsts.CollectionDefinitionName)]
public class MongoDBSampleDomainTests : SampleDomainTests<KarTimeMongoDbTestModule>
{

}
