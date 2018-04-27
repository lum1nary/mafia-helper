namespace MafiaHelper.Core
{
    public interface IMafiaRoundResult
    {
        bool IsGameComplete { get; }

        IMafiaRound CompletedRound { get; }
    }
}