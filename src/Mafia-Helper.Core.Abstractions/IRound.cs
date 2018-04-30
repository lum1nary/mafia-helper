using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public interface IRound
    {
        int RoundNumber { get; }

        IReadOnlyList<IChooseAction> Actions { get; }

        IReadOnlyList<IVoteAction> Votes { get; }

        IReadOnlyList<INeutralizeAction> NeutralizedEffects { get; }
    }
}