using MafiaHelper.Core;
using MafiaHelper.Core.Rules;
using static System.Console;

namespace MafiaHelper.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Welcome to mafia helper!");

            var emulator = new MafiaScenarioEmulator();
            emulator.TeamFactory = new TeamFactory();
            emulator.Rules = new ClassicMafiaRules();

            emulator.CreateGame();

            AddPlayers(emulator);

            emulator.StartGame();

            IMafiaRoundResult result;

            do
            {
                result = PlayRound(emulator);
                WriteLine(result.ToString());

            } while (!result.IsGameComplete);

            WriteLine("Congrats! Win Team is: " + result.WinTeamName);

            ReadKey();
        }

        private static void AddPlayers(MafiaScenarioEmulator emulator)
        {
            Write("Enter players count:");
            var pCount = int.Parse(ReadLine());

            for (int i = 0; i < pCount; i++)
            {
                WriteLine($"Enter team for player {i + 1}");
                var card = ReadLine();
                emulator.AddPlayer(i + 1, card);
            }
        }

        private static IMafiaRoundResult PlayRound(MafiaScenarioEmulator emulator)
        {
            var teamEnumerator = emulator.StartRound();

            foreach (var team in teamEnumerator)
            {
                WriteLine($"Team {team.TeamName} enter your choice:");
                var choice = int.Parse(ReadLine());
                emulator.AddChoice(team, choice);
            }

            return emulator.ApplyRound(teamEnumerator);
        }
    }
}
