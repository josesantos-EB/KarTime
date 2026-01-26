using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarTime.Sessions;

public interface ISessionAppService
{
    Task<SessionOutputDto> CreateAsync(int kartNumber, SessionInputDto input);
    Task<SessionOutputDto> FinishAsync(int kartNumber, EndSessionInputDto input);
    Task<List<SessionOutputDto>> GetListAsync(int kartNumber);
    Task<SessionDetailsVo?> GetAsync(Guid sessionId);
}