// IGameViewModel.cs

using TennisGameSimulationInterfaces.Models;

namespace TennisGameSimulationInterfaces.ViewModels;

public interface IGameViewModel
{
    bool IsGameOver { get; }
    IPlayer PlayerA { get; }
    IPlayer PlayerB { get; }
    string Score { get; }
    void IncreaseScoreA();
    void IncreaseScoreB();
}