using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code_2018
{
  class Day2
  {
    public void Part1()
    {
      using(var file = new StreamReader("day2.txt"))
      {
        string line;
        var twos = new HashSet<string>();
        var threes = new HashSet<string>();
        while((line = file.ReadLine()) != null)
        {
          var charMap = new Dictionary<char, int>();
          line.ToList().ForEach(c => {
            if (!charMap.ContainsKey(c))
            {
              charMap[c] = 1;
            }
            else
            {
              charMap[c]++;
            }
          });

          charMap.Keys.ToList().ForEach(k => {
            if (charMap[k] == 2)
            {
              twos.Add(line);
            }
            else if (charMap[k] == 3)
            {
              threes.Add(line);
            }
          });
        }

        Console.WriteLine($"Part 1: {twos.Count * threes.Count}");
      }
    }

    public void Part2()
    {
      var lines = File.ReadAllLines("day2.txt");
      for (var i = 0; i < lines.Length; i++)
      {
        var line1 = lines[i];

        // Compare against next subsequent lines (previous ones have already been checked), for O(n log(n)) complex.
        for (var j = i + 1; j < lines.Length; j++)
        {
          var line2 = lines[j];
          var commonChars = FindCommonChars(line1, line2);
          if (commonChars.Length == (line1.Length - 1))
          {
            Console.Write($"Part 2: {commonChars}");
            return;
          }
        }
      }
    }

    protected string FindCommonChars(string line1, string line2)
    {
      var result = "";
      for (var i = 0; i < line1.Length; i++)
      {
        if (line1[i] == line2[i])
        {
          result += line1[i];
        }
      }
      return result;
    }
  }
}