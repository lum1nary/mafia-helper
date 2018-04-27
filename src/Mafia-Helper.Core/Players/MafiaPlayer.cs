using System;
using MafiaHelper.Core.Effects;
using MafiaHelper.Core.EventArgs;

namespace MafiaHelper.Core.Players
{
    public class MafiaPlayer : IMafiaPlayer
    {
        public event EventHandler<PlayerChooseEventArgs> Chose;
        public event EventHandler<PlayerChooseEventArgs> Vote;
        public int PlayerNumber { get; }
        public IMafiaCard Card { get; }
        public IPlayerState State { get; }

        public MafiaPlayer(int playerNumber, IMafiaCard card, IPlayerState state)
        {
            PlayerNumber = playerNumber;
            Card = card;
            State = state;
        }

        public void DoVote(IMafiaPlayer other)
        {
            other.State.ApplyEffect(new VoteEffect());
            Raise(Vote, other);
        }

        public void DoChoose(IMafiaPlayer other)
        {
            other.State.ApplyEffect(Card.Effect);
            Raise(Chose, other);
        }

        private void Raise(EventHandler<PlayerChooseEventArgs> eventHandler, IMafiaPlayer other)
        {
            if (eventHandler == null)
                return;

            var args = new PlayerChooseEventArgs(this, other);
            eventHandler.Invoke(this, args);
        }
    }
}