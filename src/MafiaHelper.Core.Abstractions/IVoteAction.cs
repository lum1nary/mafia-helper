namespace MafiaHelper.Core
{
    public interface IVoteAction
    {
        IMafiaPlayer SourcePlayer { get; }

        IMafiaPlayer TargetPlayer { get; }
    }
}