using System;

namespace MafiaHelper.Core
{
    public interface IMafiaPlayer
    {
        event EventHandler<IVoteAction> Vote;

        int PlayerNumber { get; }

        ITeam Team { get; }

        IPlayerState State { get; }

        void DoVote(IMafiaPlayer other);
    }
}