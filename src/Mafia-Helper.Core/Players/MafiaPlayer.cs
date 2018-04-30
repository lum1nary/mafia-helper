using System;
using MafiaHelper.Core.EventArgs;

namespace MafiaHelper.Core.Players
{
    public class MafiaPlayer : IMafiaPlayer
    {
        public event EventHandler<PlayerVoteEventArgs> Vote;

        public int PlayerNumber { get; }

        public IMafiaTeam Team { get; }

        public IPlayerState State { get; }

        public MafiaPlayer(int playerNumber, IMafiaTeam team, IPlayerState state)
        {
            PlayerNumber = playerNumber;
            Team = team;
            State = state;
        }

        public void DoVote(IMafiaPlayer other)
        {
            other.State.ApplyEffect(new VoteEffect());
            Vote?.Invoke(this, new PlayerVoteEventArgs(this, other));
        }
    }
}