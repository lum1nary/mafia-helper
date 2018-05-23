using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public interface IMafiaGame
    {
        PlayerCollection Players { get; }

        TeamCollection Teams { get; }

        IReadOnlyList<IRound> Rounds { get; }

        IMafiaRules Rules { get; }

        void Initialize();

        IRoundResult PlayNextRound(IRound round);
    }
}