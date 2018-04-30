using System.Linq;

namespace MafiaHelper.Core
{
    public class MafiaRoundResult : IMafiaRoundResult
    {
        public bool IsGameComplete { get; }
        public string WinTeamName { get; }
        public IMafiaRound CompletedRound { get; }

        public MafiaRoundResult(bool isGameComplete, IMafiaRound completedRound, string winTeamName = "")
        {
            IsGameComplete = isGameComplete;
            CompletedRound = completedRound;
            WinTeamName = winTeamName;
        }

        public override string ToString()
        {
            return $"Round {CompletedRound.RoundNumber} completed with following actions :" + 
                   string.Join("\n", CompletedRound.Actions.Select(i => i.ToString()));
        }
    }
}