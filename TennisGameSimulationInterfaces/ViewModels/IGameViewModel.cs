// IGameViewModel.cs

using TennisGameSimulationInterfaces.Models;

namespace TennisGameSimulationInterfaces.ViewModels;

public interface IGameViewModel
{
    IPlayer PlayerA { get; }
    IPlayer PlayerB { get; }
    string Score { get; }
    void IncreaseScoreA();
    void IncreaseScoreB();
    bool IsGameOver { get; }
}