using System.ComponentModel.DataAnnotations;

namespace KarTime.Sessions;

public class SessionInputDto
{
    [Range(1, 100)]
    public int HorsePower { get; set; }
    [Range(10, 10000)]
    public int? SizeOfTrackMeters { get; set; }
    [StringLength(50)]
    public string? NameOfTrack { get; set; }
}