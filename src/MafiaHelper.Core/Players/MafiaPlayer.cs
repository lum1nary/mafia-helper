using System;

namespace MafiaHelper.Core
{
    public class MafiaPlayer : IMafiaPlayer
    {
        public event EventHandler<IVoteAction> Vote;

        public int PlayerNumber { get; }

        public ITeam Team { get; }

        public IPlayerState State { get; }

        public MafiaPlayer(int playerNumber, ITeam team, IPlayerState state)
        {
            PlayerNumber = playerNumber;
            Team = team;
            State = state;
        }

        public void DoVote(IMafiaPlayer other)
        {
            other.State.Apply(new VoteEffect());
            Vote?.Invoke(this, new PlayerVoteEventArgs(this, other));
        }

        public override string ToString()
        {
            return $"Player #{PlayerNumber} ({Team.TeamName})";
        }
    }
}