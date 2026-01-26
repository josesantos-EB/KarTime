using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Volo.Abp.Modularity;
using Xunit;

namespace KarTime.Sessions;

public abstract class SessionAppServiceTest<TStartupModule> : KarTimeApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly ISessionAppService _sessionAppService;

    public SessionAppServiceTest()
    {
        _sessionAppService = GetRequiredService<ISessionAppService>();
    }

    [Fact]
    public async Task ShouldBeCreateSession()
    {
        var input = new SessionInputDto()
        {
            HorsePower = 15,
            SizeOfTrackMeters = 510
        };

        var response = await _sessionAppService.CreateAsync(10, input);
        
        Assert.NotNull(response);
        Assert.NotNull(response?.Id);
    }

    [Fact]
    public async Task ShouldBeFinishedSession()
    {
        await InsertSessionKart10Async();
        var bytes = "Conteúdo da imagem"u8.ToArray();
        var stream = new MemoryStream(bytes);

        IFormFile formFile = new FormFile(
            baseStream: stream,
            baseStreamOffset: 0,
            length: bytes.Length,
            name: "file",
            fileName: "teste.txt"
        )
        {
            Headers = new HeaderDictionary(),
            ContentType = "text/plain"
        };
        
        var sessionOutputDto = await _sessionAppService.FinishAsync(10, new EndSessionInputDto()
        {
            PhotoFinish = formFile,
        });

        Assert.NotNull(sessionOutputDto?.Id);
        Assert.NotNull(sessionOutputDto.EndTime);
    }

    [Fact]
    public async Task ShouldBeThrowExceptionSessionNotFound()
    {
        try
        {
            await _sessionAppService.FinishAsync(10, new());
        }
        catch (Exception e)
        {
            Assert.NotNull(e);
            Assert.Equal("Sessão não encontrado(a).", e.Message);
        }
    }

    [Fact]
    public async Task ShouldBeThrowExceptionKartAlreadyUse()
    {
        var input = new SessionInputDto()
        {
            HorsePower = 15,
            SizeOfTrackMeters = 510
        };
        await InsertSessionKart10Async();
        
        try
        {
            var response = await _sessionAppService.CreateAsync(10, input);
        }
        catch (Exception e)
        {
            Assert.NotNull(e);
            Assert.Equal("Não é possível inserir sessão pois o kart escolhido já esta em outra sessão ativa.", e.Message);
        }
    }

    private async Task InsertSessionKart10Async()
    {
        await _sessionAppService.CreateAsync(10, new SessionInputDto()
        {
            HorsePower = 15,
            SizeOfTrackMeters = 510
        });
    }
}