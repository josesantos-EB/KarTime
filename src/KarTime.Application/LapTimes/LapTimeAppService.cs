using System.Threading.Tasks;
using KarTime.Laps;
using KarTime.Localization;
using KarTime.Sessions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace KarTime.LapTimes;

public class LapTimeAppService: ApplicationService
{
    private readonly ISessionRepository _sessionRepository;
    
    public LapTimeAppService(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
        LocalizationResource = typeof(KarTimeResource);
    }
    
    [Authorize]
    [HttpPost("kart/{kartNumber}/lap-time")]
    public async Task<bool> CreateLapTimeAsync(int kartNumber, LapTimeInputDto input)
    {
        var session = await _sessionRepository.FindAsync(ent => ent.KartNumber == kartNumber && ent.EndTime == null)
            ?? throw new UserFriendlyException(L["NotFound", "Sessão"]);
        
        session.AddLap(input.LapTime);
        
        await _sessionRepository.UpdateAsync(session);
        return true;
    }
}