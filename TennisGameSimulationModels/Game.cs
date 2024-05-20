// Game.cs

using TennisGameSimulationInterfaces.Models;

namespace TennisGameSimulationModels;

public class Game : IGame
{
    public IPlayer PlayerA { get; set; }
    public IPlayer PlayerB { get; set; }
    public string Score => $"{PlayerA.Name}: {PlayerA.Score}, {PlayerB.Name}: {PlayerB.Score}";
}