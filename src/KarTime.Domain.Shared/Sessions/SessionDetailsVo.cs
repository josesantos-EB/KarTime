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
    public double? TimeOfBestLap { get; set; }
    public double? MileageOfBestLap { get; set; }
    public string? Base64OfPhotoFinish { get; set; }
}