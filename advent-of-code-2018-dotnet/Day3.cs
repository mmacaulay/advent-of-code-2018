using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code_2018_dotnet
{
  class FabricSquare
  {
    public HashSet<string> ClaimIDs = new HashSet<string>();
  }

  class Claim
  {
    public string ID { get; set; }
    public int LeftOffset { get; set; }
    public int TopOffset { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public static Claim Parse(string line)
    {
      // #123 @ 3,2: 5x4
      var result = new Claim();
      
      var parts = line.Split(" ");
      result.ID = parts[0].Substring(1, parts[0].Length - 1);

      var offsets = parts[2].Substring(0, parts[2].Length - 1).Split(",");
      result.LeftOffset = Convert.ToInt32(offsets[0]);
      result.TopOffset = Convert.ToInt32(offsets[1]);

      var dimensions = parts[3].Split("x");
      result.Width = Convert.ToInt32(dimensions[0]);
      result.Height = Convert.ToInt32(dimensions[1]);

      return result;
    }
  }
  class Day3
  {
    public FabricSquare[,] CreateFabric()
    {
      var fabric = new FabricSquare[1000, 1000];
      for(var x = 0; x < 1000; x++)
      {
        for(var y = 0; y < 1000; y++)
        {
          fabric[x, y] = new FabricSquare();
        }
      }
      return fabric;
    }
    public void Run()
    {
      var fabric = CreateFabric();
      var claims = new Dictionary<int, Claim>();
      var intactClaims = new HashSet<string>();
      using(var file = new StreamReader("day3.txt"))
      {
        string line;
        while((line = file.ReadLine()) != null)
        {
          var claim = Claim.Parse(line);
          intactClaims.Add(claim.ID);
          for (var x = claim.LeftOffset; x < claim.LeftOffset + claim.Width; x++)
          {
            for (var y = claim.TopOffset; y < claim.TopOffset + claim.Height; y++)
            {
              fabric[x, y].ClaimIDs.Add(claim.ID);
              if (fabric[x, y].ClaimIDs.Count > 1)
              {
                fabric[x, y].ClaimIDs.ToList().ForEach(id => { intactClaims.Remove(id); });
              }
            }
          }
        }
      }

      var overlapCount = 0;
      for(var x = 0; x < 1000; x++)
      {
        for(var y = 0; y < 1000; y++)
        {
          if(fabric[x, y].ClaimIDs.Count > 1) overlapCount++;
        }
      }

      Console.WriteLine($"Part 1: {overlapCount}");
      Console.WriteLine($"Part 1: {intactClaims.First()}");
    }
  }
}