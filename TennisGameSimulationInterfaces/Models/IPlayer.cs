// IPlayer.cs

namespace TennisGameSimulationInterfaces.Models;

public interface IPlayer
{
    string Name { get; set; }
    int Score { get; set; }
}