using System;
using Volo.Abp.Domain.Repositories;

namespace KarTime.Sessions;

public interface ISessionRepository: IRepository<Session, Guid>
{
}