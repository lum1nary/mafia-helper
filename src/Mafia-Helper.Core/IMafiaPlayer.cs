using System;
using MafiaHelper.Core.EventArgs;

namespace MafiaHelper.Core
{
    public interface IMafiaPlayer
    {
        event EventHandler<PlayerChooseEventArgs> Chose;
        event EventHandler<PlayerChooseEventArgs> Vote;

        int PlayerNumber { get; }

        IMafiaCard Card { get; }

        IPlayerState State { get; }

        void DoVote(IMafiaPlayer other);

        void DoChoose(IMafiaPlayer other);
    }
}