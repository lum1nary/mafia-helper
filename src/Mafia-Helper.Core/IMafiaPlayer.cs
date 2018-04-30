using System;
using MafiaHelper.Core.EventArgs;

namespace MafiaHelper.Core
{
    public interface IMafiaPlayer
    {
        event EventHandler<PlayerVoteEventArgs> Vote;

        int PlayerNumber { get; }

        IMafiaTeam Team { get; }

        IPlayerState State { get; }

        void DoVote(IMafiaPlayer other);
    }
}