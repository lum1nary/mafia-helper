using System.Collections.Generic;
using MafiaHelper.Core.EventArgs;

namespace MafiaHelper.Core
{
    public class MafiaRound : IMafiaRound
    {
        public IReadOnlyList<PlayerChooseEventArgs> Actions { get; }
        public IReadOnlyList<PlayerVoteEventArgs> Votes { get; }

        public int RoundNumber { get; }

        public MafiaRound(int roundNumber, IEnumerable<PlayerChooseEventArgs> actions, IEnumerable<PlayerVoteEventArgs> votes)
        {
            RoundNumber = roundNumber;
            Actions = new List<PlayerChooseEventArgs>(actions);
            Votes = new List<PlayerVoteEventArgs>(votes);
        }
    }
}