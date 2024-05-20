// IGame.cs

namespace TennisGameSimulationInterfaces.Models;

public interface IGame
{
    IPlayer PlayerA { get; set; }
    IPlayer PlayerB { get; set; }
    string Score { get; }
}