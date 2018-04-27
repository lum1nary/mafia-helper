using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public interface IMafiaGame
    {
        IReadOnlyList<IMafiaPlayer> Players { get; }

        IReadOnlyList<IMafiaRound> Rounds { get; }

        IMafiaRules Rules { get; }

        IMafiaRoundResult PlayNextRound(IMafiaRound round);
    }
}