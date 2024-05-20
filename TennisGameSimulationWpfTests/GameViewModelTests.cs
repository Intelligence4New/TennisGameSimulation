// GameViewModelTests.cs

using Moq;
using TennisGameSimulationInterfaces.Models;
using TennisGameSimulationModels;
using TennisGameSimulationWpf.ViewModels;

namespace TennisGameSimulationWpfTests;

public class GameViewModelTests
{
    private readonly Mock<IGame> _mockTennisGame;
    private readonly GameViewModel _viewModel;
    private readonly IPlayer _mockPlayerA;
    private readonly IPlayer _mockPlayerB;

    public GameViewModelTests()
    {
        _mockPlayerA = new Player("Player A")
        {
            Score = 0
        };
        _mockPlayerB = new Player("Player B")
        {
            Score = 0
        };
        _mockTennisGame = new Mock<IGame>(MockBehavior.Strict);
        _viewModel = new GameViewModel(_mockTennisGame.Object);
        _mockTennisGame.VerifyAll();
    }

    [Fact]
    public void IncreaseScoreACommand_ShouldIncreaseScoreA()
    {
        _mockTennisGame.Setup(game => game.IncreaseScoreA());
        _viewModel.IncreaseScoreACommand.Execute(null);
        _mockTennisGame.Verify(game => game.IncreaseScoreA(), Times.Once);
    }

    [Fact]
    public void IncreaseScoreBCommand_ShouldIncreaseScoreB()
    {
        _mockTennisGame.Setup(game => game.IncreaseScoreB());
        _viewModel.IncreaseScoreBCommand.Execute(null);
        _mockTennisGame.Verify(game => game.IncreaseScoreB(), Times.Once);
    }

    [Fact]
    public void Score_ShouldReturnCurrentScore()
    {
        _mockTennisGame.Setup(game => game.GetScore()).Returns("15 - 0");
        Assert.Equal("15 - 0", _viewModel.Score);
    }

    [Fact]
    public void IsGameOver_ShouldReturnTrueIfGameIsOver()
    {
        _mockTennisGame.Setup(game => game.IsGameOver).Returns(true);
        Assert.True(_viewModel.IsGameOver);
    }
}