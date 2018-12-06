using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code_2018_dotnet
{
  public class Record
  {
    public string Date { get; set; }
    public string Command { get; set; }
  }

  public class Guard
  {
    public Guard(int id) => ID = id;
    public int ID { get; set; }
    public int TotalMinutesAsleep = 0;
    public Dictionary<int, int> MinutesAsleep = new Dictionary<int, int>();
  }

  public class Day4
  {
    public void Run()
    {
      var records = File.ReadAllLines("day4.txt").Select(line => {
        var record = new Record();

        record.Date = line.Substring(1, 16);
        record.Command = line.Substring(19);

        return record;
      }).OrderBy(record => record.Date);

      var guardMap = TrackGuards(records.ToList());

      var sleepiestGuard = guardMap.Values.GroupBy(guard => {
        return guard.TotalMinutesAsleep;
      }).OrderBy(grouping => grouping.Key).Last().First();

      var maxSleepyMoment = sleepiestGuard.MinutesAsleep.Values.Max();
      var sleepiestMoment = sleepiestGuard.MinutesAsleep.Keys.FirstOrDefault(k => {
        return sleepiestGuard.MinutesAsleep[k] == maxSleepyMoment;
      });

      Console.WriteLine($"Part 1: {sleepiestGuard.ID * sleepiestMoment}");
    }

    public Dictionary<int, Guard> TrackGuards (List<Record> records)
    {
      var guardMap = new Dictionary<int, Guard>();
      var currentGuardID = 0;
      var sleepStart = 0;
      var sleepiestMoment = 0;
      var highestSleepCount = 0;
      var sleepiestGuardID = 0;
      records.ForEach(record => {
        if (record.Command.StartsWith("Guard"))
        {
          currentGuardID = Convert.ToInt32(record.Command.Split(" ")[1].Substring(1));
          if(!guardMap.ContainsKey(currentGuardID))
          {
            guardMap[currentGuardID] = new Guard(currentGuardID);
          }
        }
        else if (record.Command == "falls asleep")
        {
          sleepStart = GetMinute(record.Date);
        }
        else // wakes up
        {
          var sleepEnd = GetMinute(record.Date);
          guardMap[currentGuardID].TotalMinutesAsleep += sleepEnd - sleepStart;
          for (var i = sleepStart; i < sleepEnd; i++)
          {
            if (!guardMap[currentGuardID].MinutesAsleep.ContainsKey(i))
            {
              guardMap[currentGuardID].MinutesAsleep[i] = 1;
            }
            else
            {
              guardMap[currentGuardID].MinutesAsleep[i]++;
              if (guardMap[currentGuardID].MinutesAsleep[i] > highestSleepCount)
              {
                sleepiestMoment = i;
                highestSleepCount = guardMap[currentGuardID].MinutesAsleep[i];
                sleepiestGuardID = currentGuardID;
              }
            }
          }
        }
      });
      Console.WriteLine($"Part 2: {sleepiestGuardID * sleepiestMoment}");
      return guardMap;
    }

    public int GetMinute(string date)
    {
      // 1518-09-16 00:04
      return Convert.ToInt32(date.Split(" ")[1].Split(":")[1]);
    }
  }
}