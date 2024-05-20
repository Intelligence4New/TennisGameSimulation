// IGame.cs

namespace TennisGameSimulationInterfaces.Models;

public interface IGame
{
    IPlayer PlayerA { get; set; }
    IPlayer PlayerB { get; set; }
    void IncreaseScoreA();
    void IncreaseScoreB();
    string GetScore();
    bool IsGameOver { get; }
}