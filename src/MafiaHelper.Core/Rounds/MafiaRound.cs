using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public class MafiaRound : IRound
    {
        public int RoundNumber { get; }

        public IReadOnlyList<IChooseAction> Actions { get; }
        public IReadOnlyList<IVoteAction> Votes { get; }
        public IReadOnlyList<INeutralizeAction> NeutralizedEffects { get; }

        public MafiaRound(
            int roundNumber,
            IEnumerable<IChooseAction> actions,
            IEnumerable<IVoteAction> votes,
            IEnumerable<INeutralizeAction> neutralizedEffects)
        {
            RoundNumber = roundNumber;
            Actions = new List<IChooseAction>(actions);
            Votes = new List<IVoteAction>(votes);
            NeutralizedEffects = new List<INeutralizeAction>(neutralizedEffects);
        }
    }
}