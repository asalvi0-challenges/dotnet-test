using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using LeagueCalc;

namespace LeagueCalc.Tests;

public class UnitTest1
{
    [Fact]
    public void ParseInput_CalculatesCorrectPoints()
    {
        // Arrange
        var league = new League();
        var input = new List<string>
        {
            "Lions 3, Snakes 3",
            "Tarantulas 1, FC Awesome 0",
            "Lions 1, FC Awesome 1",
            "Tarantulas 3, Snakes 1",
            "Lions 4, Grouches 0"
        };

        // Act
        league.ParseInput(input);

        // Assert
        Assert.Equal(5, league.GetRankings().Count());
        Assert.Equal(6, league.GetRankings().First(t => t.Name == "Tarantulas").Points);
        Assert.Equal(5, league.GetRankings().First(t => t.Name == "Lions").Points);
        Assert.Equal(1, league.GetRankings().First(t => t.Name == "FC Awesome").Points);
        Assert.Equal(1, league.GetRankings().First(t => t.Name == "Snakes").Points);
        Assert.Equal(0, league.GetRankings().First(t => t.Name == "Grouches").Points);
    }

    [Fact]
    public void ParseInput_CalculatesCorrectRanks()
    {
        // Arrange
        var league = new League();
        var input = new List<string>
        {
            "Lions 3, Snakes 3",
            "Tarantulas 1, FC Awesome 0",
            "Lions 1, FC Awesome 1",
            "Tarantulas 3, Snakes 1",
            "Lions 4, Grouches 0"
        };

        // Act
        league.ParseInput(input);

        // Assert
        Assert.Equal(1, league.GetRankings().First(t => t.Name == "Tarantulas").Rank);
        Assert.Equal(2, league.GetRankings().First(t => t.Name == "Lions").Rank);
        Assert.Equal(3, league.GetRankings().First(t => t.Name == "FC Awesome").Rank);
        Assert.Equal(3, league.GetRankings().First(t => t.Name == "Snakes").Rank);
        Assert.Equal(5, league.GetRankings().First(t => t.Name == "Grouches").Rank);
    }

    [Fact]
    public void ParseInput_HandleTiedTeamsCorrectly()
    {
        // Arrange
        var league = new League();
        var input = new List<string>
        {
            "Lions 3, Snakes 3",
            "Tarantulas 1, FC Awesome 0",
            "Lions 1, FC Awesome 1",
            "Tarantulas 3, Snakes 1",
            "Lions 4, Grouches 0"
        };

        // Act
        league.ParseInput(input);

        // Assert
        Assert.Collection(league.GetRankings(),
            team => Assert.Equal("Tarantulas", team.Name),
            team => Assert.Equal("Lions", team.Name),
            team => Assert.Equal("FC Awesome", team.Name),
            team => Assert.Equal("Snakes", team.Name),
            team => Assert.Equal("Grouches", team.Name));
    }

    [Fact]
    public void GetRankings_ReturnsEmptyList_WhenNoInputProvided()
    {
        // Arrange
        var league = new League();

        // Act
        var rankings = league.GetRankings().ToList();

        // Assert
        Assert.Empty(rankings);
    }

    [Fact]
    public void GetRankings_ReturnsTeamsInCorrectOrder()
    {
        // Arrange
        var league = new League();
        var input = new List<string>
        {
            "Tarantulas 1, FC Awesome 0",
            "Lions 4, Grouches 0",
            "Lions 3, Snakes 3",
            "Lions 1, FC Awesome 1",
            "Tarantulas 3, Snakes 1"
        };
        league.ParseInput(input);

        // Act
        var rankings = league.GetRankings().ToList();

        // Assert
        Assert.Equal("Tarantulas", rankings[0].Name);
        Assert.Equal("Lions", rankings[1].Name);
        Assert.Equal("FC Awesome", rankings[2].Name);
        Assert.Equal("Snakes", rankings[3].Name);
        Assert.Equal("Grouches", rankings[4].Name);
    }
}
