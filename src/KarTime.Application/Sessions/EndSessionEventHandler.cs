using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace KarTime.Sessions;

public class EndSessionEventHandler: ILocalEventHandler<EndSessionEto>, ITransientDependency
{
    private readonly ISessionManager _sessionManager;
    public EndSessionEventHandler(ISessionManager sessionManager)
    {
        _sessionManager = sessionManager;
    }
    
    public async Task HandleEventAsync(EndSessionEto eventData)
    {
        var session = await _sessionManager.GetSessionDetailsAsync(eventData.SessionId);
        SendEmailDetails(session);
    }

    private void SendEmailDetails(SessionDetailsVo session)
    {
        // Aqui poderia ser uma integração com algum serviço de notificações (Email, SMS, etc.)
        Console.WriteLine(@$"
Melhor volta: {session.NumberOfBestLap}
Tempo da melhor volta: {session.TimeOfBestLap}
Velocidade média da melhor volta: {session.MileageOfBestLap}
");
    }
}