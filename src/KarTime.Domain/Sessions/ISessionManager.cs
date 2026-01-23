using System;
using System.IO;
using System.Threading.Tasks;

namespace KarTime.Sessions;

public interface ISessionManager
{
    Task<bool> ExistsActiveSessionAsync(int kartNumber);
    Task<Session> EndSessionAsync(int kartNumber, Stream? photoStream);
    Task<SessionDetailsVo> GetSessionDetailsAsync(Guid sessionId);
}