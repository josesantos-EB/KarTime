using System;

namespace KarTime.Laps;

public class Lap
{
    public Lap(int number, double timeOfLap)
    {
        Number = number;
        TimeOfLap = timeOfLap;
    }

    public int Number { get; set; }
    public double TimeOfLap { get; set; }
}