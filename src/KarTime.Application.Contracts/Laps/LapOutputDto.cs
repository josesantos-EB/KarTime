using System;

namespace KarTime.Laps;

public class LapOutputDto
{
    public double LapTime { get; set; }
    public Guid SessionId { get; set; }
}