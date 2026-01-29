using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KarTime.Laps;
using KarTime.Localization;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace KarTime.Sessions;

public class SessionManager: DomainService, ISessionManager
{
    private readonly ISessionRepository _sessionRepository;
    private readonly IBlobContainer<SessionContainer> _blobContainer;
    private readonly IStringLocalizer<KarTimeResource> _localizer;
    public SessionManager(ISessionRepository sessionRepository, IBlobContainer<SessionContainer> blobContainer, IStringLocalizer<KarTimeResource> localizer)
    {
        _sessionRepository = sessionRepository;
        _blobContainer = blobContainer;
        _localizer = localizer;
    }

    public async Task<bool> ExistsActiveSessionAsync(int kartNumber)
    {
        return await _sessionRepository.AnyAsync(ent => ent.KartNumber == kartNumber && ent.EndTime == null);
    }

    public async Task<Session> EndSessionAsync(int kartNumber, Stream? photoStream)
    {
        var session = await _sessionRepository.FindAsync(ent => ent.KartNumber == kartNumber && ent.EndTime == null);
        if (session is null)
            throw new UserFriendlyException(_localizer["NotFound", "Sessão"]);

        if (photoStream is not null)
        {
            await _blobContainer.SaveAsync(session.Id.ToString(), photoStream);
        }
        session.FinishSession();
        await _sessionRepository.UpdateAsync(session);
        return session;
    }

    public async Task<SessionDetailsVo> GetSessionDetailsAsync(Guid sessionId)
    {
        var session = await _sessionRepository.GetAsync(sessionId);
        if (session.EndTime is null)
            throw new UserFriendlyException(_localizer["SessionStillActive"]);

        var response = new SessionDetailsVo()
        {
            Base64OfPhotoFinish = await GetBase64OfPhotoFinishAsync(sessionId),
            EndTime = session.EndTime,
            HorsePower = session.HorsePower,
            SizeOfTrackMeters = session.SizeOfTrackMeters,
            StartTime = session.StartTime,
            Id = session.Id,
            NumberOfLaps = session.Laps.Count,
        };

        var bestLap = GetBestLap(session.Laps);

        if (bestLap is null)
            return response;

        response.TimeOfBestLap = Round3Digits(bestLap.TimeOfLap);
        response.MileageOfBestLap = CalculateMileage(bestLap.TimeOfLap, session.SizeOfTrackMeters);
        response.NumberOfBestLap = bestLap.Number;
        return response;
    }

    private async Task<string?> GetBase64OfPhotoFinishAsync(Guid sessionId)
    {
        var bytes = await _blobContainer.GetAllBytesOrNullAsync(sessionId.ToString());
        return bytes is null ? null : Convert.ToBase64String(bytes);
    }

    private static decimal Round3Digits(double value) => Math.Round((decimal)value, 3);

    private static decimal CalculateMileage(double lapTime, int sizeOfTrackMeters) => 
                                        Round3Digits(sizeOfTrackMeters * 3.6 / lapTime);
    
    private static Lap? GetBestLap(List<Lap> laps)
        => laps.MinBy(ent => ent.TimeOfLap);
}