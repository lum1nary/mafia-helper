using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public interface IMafiaGame
    {
        IReadOnlyList<IMafiaPlayer> Players { get; }

        IReadOnlyList<ITeam> Teams { get; }

        IReadOnlyList<IRound> Rounds { get; }

        IMafiaRules Rules { get; }

        void Initialize();

        IRoundResult PlayNextRound(IRound round);
    }
}