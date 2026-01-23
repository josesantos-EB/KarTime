using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KarTime.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.Settings;

namespace KarTime.Sessions;

public class SessionAppService: ApplicationService
{
    private readonly ISessionRepository _sessionRepository;
    private readonly ISessionManager _sessionManager;
    private readonly ISettingProvider _settingProvider;
    private readonly IDistributedCache<SessionDetailsVo> _cache;
    private const int DefaultSizeOfTrack = 500;

    public SessionAppService(ISessionRepository sessionRepository, ISessionManager sessionManager, ISettingProvider settingProvider, IDistributedCache<SessionDetailsVo> cache)
    {
        _sessionRepository = sessionRepository;
        _sessionManager = sessionManager;
        _settingProvider = settingProvider;
        _cache = cache;
        LocalizationResource = typeof(KarTimeResource);
    }
    
    [Authorize]
    [HttpPost("/kart/{kartNumber}/session")]
    public async Task<SessionOutputDto> CreateAsync(int kartNumber, SessionInputDto input)
    {
        if (await _sessionManager.ExistsActiveSessionAsync(kartNumber))
            throw new UserFriendlyException(L["FailInsertSessionKartUsed"]);

        var sizeOfTrackMeters = input.SizeOfTrackMeters ?? await GetSizeOfTrackBySettingsAsync(input.NameOfTrack);
        var session = new Session(kartNumber, input.HorsePower, sizeOfTrackMeters);
        await _sessionRepository.InsertAsync(session, true);
        return GetSessionOutputDto(session);
    }

    [Authorize]
    [HttpPut("/kart/{kartNumber}/session")]
    public async Task<SessionOutputDto> FinishAsync(int kartNumber,[FromForm] EndSessionInputDto input)
    {
        var photoFinishStream = input.PhotoFinish?.OpenReadStream();
        var session = await _sessionManager.EndSessionAsync(kartNumber, photoFinishStream);
        return GetSessionOutputDto(session);
    }
    
    [Authorize]
    [HttpGet("/kart/{kartNumber}/session")]
    public async Task<List<SessionOutputDto>> GetListAsync(int kartNumber)
    {
        var sessions = await _sessionRepository.GetListAsync(ent=> ent.KartNumber == kartNumber);
        return sessions.ConvertAll(GetSessionOutputDto);
    }

    [Authorize]
    [HttpGet("/session/{sessionId}")]
    public async Task<SessionDetailsVo?> GetAsync(Guid sessionId)
    {
        return await _cache.GetOrAddAsync(sessionId.ToString(),
            async () => await _sessionManager.GetSessionDetailsAsync(sessionId), 
            () => new DistributedCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30)
                });
    }    

    private static SessionOutputDto GetSessionOutputDto(Session session) 
        => new (session.Id, session.KartNumber, session.HorsePower, session.SizeOfTrackMeters, session.StartTime, session.EndTime);
    
    private async Task<int> GetSizeOfTrackBySettingsAsync(string trackName)
    {
        var settings = await _settingProvider.GetOrNullAsync($"Track.{trackName}");
        if(int.TryParse(settings, out var result) && result > 0)
            return result;
        return DefaultSizeOfTrack;
    }
}
