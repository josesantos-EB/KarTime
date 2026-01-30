using System;

namespace KarTime.Sessions;

public class EndSessionEto
{
    public Guid SessionId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int KartNumber { get; set; }
}