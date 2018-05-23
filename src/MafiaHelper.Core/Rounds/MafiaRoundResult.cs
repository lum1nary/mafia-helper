using System.Linq;

namespace MafiaHelper.Core
{
    public class MafiaRoundResult : IRoundResult
    {
        public bool IsGameComplete { get; }
        public string WinTeamName { get; }
        public IRound CompletedRound { get; }

        public MafiaRoundResult(bool isGameComplete, IRound completedRound, string winTeamName = "")
        {
            IsGameComplete = isGameComplete;
            CompletedRound = completedRound;
            WinTeamName = winTeamName;
        }

        public override string ToString()
        {
            return $"Round {CompletedRound.RoundNumber} completed! " +
                   $"Round actions:\n" + string.Join("\n", CompletedRound.Actions.Select(i => i.ToString())) + "\n" +
                   $"Round Votes:\n" + string.Join("\n", CompletedRound.Votes.Select(i => i.ToString()));
        }
    }
}