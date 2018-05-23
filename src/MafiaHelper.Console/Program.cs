using System.Linq;
using MafiaHelper.Classic;
using MafiaHelper.Core;
using static System.Console;

namespace MafiaHelper.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Welcome to mafia helper!");

            var emulator = new MafiaRunner();
            emulator.TeamFactory = new TeamFactory();
            emulator.Rules = new ClassicMafiaRules();

            emulator.CreateGame();

            AddPlayers(emulator);

            emulator.StartGame();

            IRoundResult result;

            do
            {
                result = PlayRound(emulator);
                WriteLine(result.ToString());

            } while (!result.IsGameComplete);

            WriteLine("Congrats! Win Team is: " + result.WinTeamName);

            ReadKey();
        }

        private static void AddPlayers(MafiaRunner emulator)
        {
            Write("Enter players count:");
            var pCount = int.Parse(ReadLine());
            var teams =  string.Join(", ",emulator.Rules.DefaultTeams.Select(i => $"({i.ToString()})"));

            for (int i = 0; i < pCount; i++)
            {
                WriteLine($"Enter team for Player #{i + 1} \t Avaliable teams: {teams}");
                var card = ReadLine();
                emulator.AddPlayer(i + 1, card);
            }
        }

        private static IRoundResult PlayRound(MafiaRunner emulator)
        {
            var teamEnumerator = emulator.StartRound();

            foreach (var team in teamEnumerator)
            {
                var otherPlayers = emulator.Game.Players.Except(team.Participants);
                WriteLine($"{team} enter your choice: \t {string.Join(", " ,otherPlayers.Select(i => i.ToString()))}");
                var choice = int.Parse(ReadLine());
                emulator.AddChoice(team, choice);
            }

            return emulator.ApplyRound(teamEnumerator);
        }
    }
}
