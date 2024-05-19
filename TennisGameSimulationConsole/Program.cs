using static System.Console;

namespace TennisGameSimulationConsole;

internal class Program
{
    private static bool HasWinner(int playerAScore, int playerBScore)
    {
        return (playerAScore >= 4 && playerAScore - playerBScore >= 2)
               || (playerBScore >= 4 && playerBScore - playerAScore >= 2);
    }

    private static void Main()
    {
        var playerAScore = 0;
        var playerBScore = 0;

        while (!HasWinner(playerAScore, playerBScore))
        {
            WriteLine(
                $"Current Score: Player A - {ReturnTennisScore(playerAScore, playerBScore)}, Player B - {ReturnTennisScore(playerBScore, playerAScore)}");
            WriteLine("Press 'A' for Player A or 'B' for Player B:");

            var input = ReadKey().KeyChar;
            WriteLine();

            switch (input)
            {
                case 'A' or 'a':
                    playerAScore++;
                    break;
                case 'B' or 'b':
                    playerBScore++;
                    break;
                default:
                    WriteLine("Invalid input. Please press 'A' or 'B'.");
                    break;
            }
        }

        WriteLine($"Player {(playerAScore > playerBScore ? 'A' : 'B')} wins!");
        ReadLine();
    }

    private static string ReturnTennisScore(int playerAScore, int playerBScore)
    {
        return playerAScore switch
        {
            0 => "Null",
            1 => "15",
            2 => "30",
            3 => playerBScore == 3 ? "Deuce" : "40",
            >= 4 => (playerAScore - playerBScore) switch
            {
                // handle Deuce and Adv correctly
                0 => "Deuce",
                >= 1 => "Adv",
                _ => "40"
            },
            _ => "Null"
        };
    }
}