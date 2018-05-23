namespace MafiaHelper.Core
{
    public interface IRoundResult
    {
        bool IsGameComplete { get; }

        string WinTeamName { get; }

        IRound CompletedRound { get; }
    }
}