using System.Collections.Generic;
using MafiaHelper.Core.EventArgs;

namespace MafiaHelper.Core
{
    public interface IMafiaRound
    {
        int RoundNumber { get; }

        IReadOnlyList<PlayerChooseEventArgs> Actions { get; }

        IReadOnlyList<PlayerVoteEventArgs> Votes { get; }
    }
}