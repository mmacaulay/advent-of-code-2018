using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code_2018
{
  class Day2
  {
    public void Run()
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

        Console.WriteLine(twos.Count * threes.Count);
      }
    }
  }
}