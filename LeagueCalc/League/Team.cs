namespace LeagueCalc;

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
