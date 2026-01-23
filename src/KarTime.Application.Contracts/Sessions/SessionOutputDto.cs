using System;

namespace KarTime.Sessions;

public class SessionOutputDto
{
    public SessionOutputDto(Guid id, int kartNumber, int horsePower, int sizeOfTrackMeters, DateTime startTime, DateTime? endTime)
    {
        Id = id;
        KartNumber = kartNumber;
        HorsePower = horsePower;
        SizeOfTrackMeters = sizeOfTrackMeters;
        StartTime = startTime;
        EndTime = endTime;
    }

    public Guid Id { get; set; }
    public int KartNumber { get; set; }
    public int HorsePower { get; set; }
    public int SizeOfTrackMeters { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}