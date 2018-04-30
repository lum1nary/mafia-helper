using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public interface IMafiaGame
    {
        IReadOnlyList<IMafiaPlayer> Players { get; }

        IReadOnlyList<IMafiaTeam> Teams { get; }

        IReadOnlyList<IMafiaRound> Rounds { get; }

        IMafiaRules Rules { get; }

        void Initialize();

        IMafiaRoundResult PlayNextRound(IMafiaRound round);
    }
}