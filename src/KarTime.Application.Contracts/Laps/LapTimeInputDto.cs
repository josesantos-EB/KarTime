using System.ComponentModel.DataAnnotations;

namespace KarTime.Laps;

public class LapTimeInputDto
{
    [Required]
    [Range(5, 3600)]
    public double LapTime { get; set; }
}