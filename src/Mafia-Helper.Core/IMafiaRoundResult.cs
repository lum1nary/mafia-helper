namespace MafiaHelper.Core
{
    public interface IMafiaRoundResult
    {
        bool IsGameComplete { get; }

        string WinTeamName { get; }

        IMafiaRound CompletedRound { get; }
    }
}