// Player.cs

using TennisGameSimulationInterfaces.Models;

namespace TennisGameSimulationModels;


public class Player : IPlayer
{
    public string Name { get; set; }
    public int Score { get; set; }
}