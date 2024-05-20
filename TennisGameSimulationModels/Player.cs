// Player.cs

using TennisGameSimulationInterfaces.Models;

namespace TennisGameSimulationModels;


public class Player : IPlayer
{
    public string Name { get; set; }
    public int Score { get; set; }

    public Player(string name)
    {
        Name = name;
    }

    public void ScorePoint()
    {
        Score++;
    }
}