using System;

namespace KarTime.Sessions;

public class SessionDetailsVo
{
    public Guid Id { get; set; }
    public int HorsePower { get; set; }
    public int SizeOfTrackMeters { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int? NumberOfLaps { get; set; }
    public int? NumberOfBestLap { get; set; }
    public decimal? TimeOfBestLap { get; set; }
    public decimal? MileageOfBestLap { get; set; }
    public string? Base64OfPhotoFinish { get; set; }
}