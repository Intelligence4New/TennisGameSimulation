// Game.cs

using TennisGameSimulationInterfaces.Models;
using static System.Formats.Asn1.AsnWriter;

namespace TennisGameSimulationModels;

public class Game : IGame
{
    public IPlayer PlayerA { get; set; }
    public IPlayer PlayerB { get; set; }
    public string Score => $"{PlayerA.Name}: {PlayerA.Score}, {PlayerB.Name}: {PlayerB.Score}";

    public Game()
    {
        PlayerA = new Player("Player A");
        PlayerB = new Player("Player B");
    }

    public Game(string playerAName, string playerBName)
    {
        PlayerA = new Player(playerAName);
        PlayerB = new Player(playerBName);
    }

    public bool IsGameOver => (PlayerA.Score >= 4 && PlayerA.Score - PlayerB.Score >= 2) || (PlayerB.Score >= 4 && PlayerB.Score - PlayerA.Score >= 2);
    public void IncreaseScoreA()
    {
        if (!IsGameOver)
        {
            PlayerA.Score++;
        }
    }
    public void IncreaseScoreB()
    {
        if (!IsGameOver)
        {
            PlayerB.Score++;
        }
    }
    public string GetScore()
    {
        if (IsGameOver)
        {
            return PlayerA.Score > PlayerB.Score ? "Player A wins" : "Player B wins";
        }

        var scores = new[] { "0", "15", "30", "40" };
        if (PlayerA.Score >= 3 && PlayerB.Score >= 3)
        {
            if (PlayerA.Score == PlayerB.Score) return "Deuce";
            return PlayerA.Score > PlayerB.Score ? "Advantage Player A" : "Advantage Player B";
        }

        return $"{scores[PlayerA.Score]} - {scores[PlayerB.Score]}";
    }
}