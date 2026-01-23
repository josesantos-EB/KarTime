using System;
using System.Collections.Generic;
using KarTime.Laps;
using Volo.Abp.Domain.Entities;

namespace KarTime.Sessions;
public class Session: Entity<Guid>
{
    public Session(int kartNumber, int horsePower,  int sizeOfTrackMeters)
    {
        KartNumber = kartNumber;
        HorsePower = horsePower;
        StartTime = DateTime.Now;
        SizeOfTrackMeters = sizeOfTrackMeters;
    }

    public int KartNumber { get; set; }
    public int HorsePower { get; set; }
    public int SizeOfTrackMeters { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public List<Lap> Laps { get; set; } = [];
    public int LastLap { get; set; } = 0;

    public void AddLap(double timeOfLap)
    {
        LastLap++;
        var lap = new Lap(LastLap, timeOfLap);
        Laps.Add(lap);
    }

    public void FinishSession()
    {
        EndTime = DateTime.Now;
    }


}