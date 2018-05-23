namespace MafiaHelper.Core
{
    public interface IChooseAction
    {
        ITeam Team { get; }

        IMafiaPlayer TargetPlayer { get; }
    }
}