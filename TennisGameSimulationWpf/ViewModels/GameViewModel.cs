// GameViewModel.cs

using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TennisGameSimulationInterfaces.Models;
using TennisGameSimulationInterfaces.ViewModels;
using TennisGameSimulationModels;

namespace TennisGameSimulationWpf.ViewModels;

public class GameViewModel : ObservableObject, IGameViewModel
{
    private readonly IGame _game;

    public GameViewModel()
    {
        _game = new Game();

        IncreaseScoreACommand = new RelayCommand(IncreaseScoreA, IsGameNotOver);
        IncreaseScoreBCommand = new RelayCommand(IncreaseScoreB, IsGameNotOver);
    }

    public GameViewModel(IGame game)
    {
        _game = game;

        IncreaseScoreACommand = new RelayCommand(IncreaseScoreA, IsGameNotOver);
        IncreaseScoreBCommand = new RelayCommand(IncreaseScoreB, IsGameNotOver);
    }

    public ICommand IncreaseScoreACommand { get; }
    public ICommand IncreaseScoreBCommand { get; }
    public bool IsGameOver => _game.IsGameOver;
    public IPlayer PlayerA => _game.PlayerA;
    public IPlayer PlayerB => _game.PlayerB;
    public string Score => _game.GetScore();

    public bool IsGameNotOver()
    {
        return !_game.IsGameOver;
    }

    public void IncreaseScoreA()
    {
        _game.IncreaseScoreA();
        OnPropertyChanged(nameof(Score));
        OnPropertyChanged(nameof(IsGameNotOver));
    }

    public void IncreaseScoreB()
    {
        _game.IncreaseScoreB();
        OnPropertyChanged(nameof(Score));
        OnPropertyChanged(nameof(IsGameNotOver));
    }
}