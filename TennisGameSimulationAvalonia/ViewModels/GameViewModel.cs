// GameViewModel.cs

using System.Reactive;
using ReactiveUI;
using TennisGameSimulationInterfaces.Models;
using TennisGameSimulationInterfaces.ViewModels;

namespace TennisGameSimulationAvalonia.ViewModels;

public class GameViewModel : ViewModelBase, IGameViewModel
{
    private readonly IGame _game;

    public GameViewModel(IGame game)
    {
        _game = game;

        IncreasePlayerAScoreCommand = ReactiveCommand.Create(IncreaseScoreA);
        IncreasePlayerBScoreCommand = ReactiveCommand.Create(IncreaseScoreB);
    }

    public ReactiveCommand<Unit, Unit> IncreasePlayerAScoreCommand { get; }
    public ReactiveCommand<Unit, Unit> IncreasePlayerBScoreCommand { get; }
    public bool IsGameOver => _game.IsGameOver;
    public IPlayer PlayerA => _game.PlayerA;
    public IPlayer PlayerB => _game.PlayerB;
    public string Score => _game.GetScore();

    public void IncreaseScoreA()
    {
        _game.IncreaseScoreA();
        this.RaisePropertyChanged(nameof(PlayerA));
        this.RaisePropertyChanged(nameof(Score));
    }

    public void IncreaseScoreB()
    {
        _game.IncreaseScoreB();
        this.RaisePropertyChanged(nameof(PlayerB));
        this.RaisePropertyChanged(nameof(Score));
    }

    public bool IsGameNotOver()
    {
        return !_game.IsGameOver;
    }
}