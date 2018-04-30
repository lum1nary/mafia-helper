namespace MafiaHelper.Core
{
    public interface IPlayerState : IRefreshable
    {
        bool IsCanChoose { get; }

        bool IsCanVote { get; }

        EffectCollection Effects { get; }

        void Apply(IActionEffect effect);
    }
}