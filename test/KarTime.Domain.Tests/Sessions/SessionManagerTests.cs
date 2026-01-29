using System;
using System.Threading.Tasks;
using NSubstitute;
using Volo.Abp.BlobStoring;
using Xunit;

namespace KarTime.Sessions;

public class SessionManagerTests
{
    [Theory]
    [InlineData(45.1,46.2,44.1, 500, 40.816)]
    [InlineData(36.15,41.21,44.99, 621, 61.842)]
    [InlineData(46.225,40.7,51.32, 412, 36.442)]
    private async Task Should_Calculate_Details_Of_Session(double firstLap, double secondLap, double thirdLap, 
                                                            int trackSize, decimal mileageOfBestLap)
    {
        var sessionRepository = Substitute.For<ISessionRepository>();
        
        var blobContainer = Substitute.For<IBlobContainer<SessionContainer>>();
        var session = new Session(1, 10, trackSize);
        session.AddLap(firstLap);
        session.AddLap(secondLap);
        session.AddLap(thirdLap);
        
        session.FinishSession();
        sessionRepository.GetAsync(Arg.Any<Guid>()).Returns(session);
        var sessionManager = new SessionManager(sessionRepository, blobContainer, null);
        
        var sessionDetails = await sessionManager.GetSessionDetailsAsync(Guid.NewGuid());
        Assert.Equal(sessionDetails.MileageOfBestLap, mileageOfBestLap);
    }
}