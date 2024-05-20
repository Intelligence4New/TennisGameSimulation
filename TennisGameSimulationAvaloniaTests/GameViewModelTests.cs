// GameViewModelTests.cs

using Moq;
using TennisGameSimulationAvalonia.ViewModels;
using TennisGameSimulationInterfaces.Models;

namespace TennisGameSimulationAvaloniaTests;

public class GameViewModelTests
{
    private readonly Mock<IGame> _mockModel;
    private readonly GameViewModel _viewModel;

    public GameViewModelTests()
    {
        _mockModel = new Mock<IGame>();
        _viewModel = new GameViewModel(_mockModel.Object);
    }

    [Fact]
    public void IncreasePlayerAScoreCommand_ShouldIncreaseScore()
    {
        _mockModel.Setup(m => m.PlayerA.Score).Returns(1);
        _viewModel.IncreasePlayerAScoreCommand.Execute().Subscribe();

        _mockModel.Verify(m => m.IncreaseScoreA(), Times.Once);
        Assert.Equal(1, _viewModel.PlayerA.Score);
    }

    [Fact]
    public void IncreasePlayerBScoreCommand_ShouldIncreaseScore()
    {
        _mockModel.Setup(m => m.PlayerB.Score).Returns(1);
        _viewModel.IncreasePlayerBScoreCommand.Execute().Subscribe();

        _mockModel.Verify(m => m.IncreaseScoreB(), Times.Once);
        Assert.Equal(1, _viewModel.PlayerB.Score);
    }

    [Fact]
    public void Score_ShouldReturnCorrectScore()
    {
        _mockModel.Setup(m => m.GetScore()).Returns("1 - 1");
        Assert.Equal("1 - 1", _viewModel.Score);
    }
}