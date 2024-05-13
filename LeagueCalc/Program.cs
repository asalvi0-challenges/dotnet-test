using System;
using System.IO;
using System.Collections.Generic;

namespace LeagueCalc;

class Program
{
    static void Main(string[] args)
    {
        var league = new League();

        if (args.Length > 0)
        {
            var lines = File.ReadAllLines(args[0]);
            league.ParseInput(lines);
        }
        else
        {
            Console.WriteLine("No input file provided. Paste results manually (press ENTER when done):");

            var lines = new List<string>();

            string? line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                lines.Add(line);
            }
            league.ParseInput(lines.ToArray());
        }

        league.PrintRankings();
    }
}
