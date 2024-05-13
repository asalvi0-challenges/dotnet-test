using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class Team
{
    public string Name { get; }
    public int Points { get; set; }
    public int Rank { get; set; }

    public Team(string name)
    {
        Name = name;
    }

    public void AddPoints(int points)
    {
        Points += points;
    }
}

public class League
{
    private Dictionary<string, Team> teams = new Dictionary<string, Team>(StringComparer.OrdinalIgnoreCase); // Ignore case for team names

    public void ParseInput(string filePath)
    {
        foreach (var line in File.ReadLines(filePath))
        {
            var parts = line.Split(',');

            var (team1Name, team1Goals) = ExtractTeamInfo(parts[0]);
            var (team2Name, team2Goals) = ExtractTeamInfo(parts[1]);

            AddResult(team1Name, team1Goals, team2Goals);
            AddResult(team2Name, team2Goals, team1Goals);
        }

        UpdateRanks();
    }

    private (string name, int goals) ExtractTeamInfo(string input)
    {
        var lastSpaceIndex = input.LastIndexOf(' ');
        var name = input.Substring(0, lastSpaceIndex).Trim();
        var goals = int.Parse(input.Substring(lastSpaceIndex + 1));

        return (name, goals);
    }

    private void AddResult(string teamName, int scoredGoals, int receivedGoals)
    {
        if (!teams.TryGetValue(teamName, out Team? team))
        {
            team = new Team(teamName);
            teams.Add(teamName, team);
        }

        if (scoredGoals > receivedGoals)
            team.AddPoints(3);
        else if (scoredGoals == receivedGoals)
            team.AddPoints(1);
    }

    private void UpdateRanks()
    {
        int rank = 1;
        int prevRank = 0;
        int prevPoints = int.MaxValue;

        foreach (var team in teams.Values.OrderByDescending(t => t.Points).ThenBy(t => t.Name))
        {
            if (team.Points < prevPoints)
            {
                prevPoints = team.Points;
                prevRank = rank;
            }
            rank++; // TODO: move this to the `if` block to avoid skipping ranks in case of a tie
            team.Rank = prevRank;
        }
    }

    public void PrintRankings()
    {
        foreach (var team in teams.Values.OrderBy(t => t.Rank).ThenBy(t => t.Name))
        {
            Console.WriteLine($"{team.Rank}. {team.Name}, {team.Points} pt{(team.Points != 1 ? "s" : "")}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the path to the input file.");
            return;
        }

        var league = new League();
        league.ParseInput(args[0]);
        league.PrintRankings();
    }
}
