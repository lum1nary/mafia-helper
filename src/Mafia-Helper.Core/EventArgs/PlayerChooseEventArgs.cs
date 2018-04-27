namespace MafiaHelper.Core.EventArgs
{
    public class PlayerChooseEventArgs : System.EventArgs
    {
        public PlayerChooseEventArgs(IMafiaPlayer sourcePlayer, IMafiaPlayer targetPlayer)
        {
            SourcePlayer = sourcePlayer;
            TargetPlayer = targetPlayer;
        }

        public IMafiaPlayer SourcePlayer { get; }

        public IMafiaPlayer TargetPlayer { get; }

        public override string ToString()
        {
            return $"Player {SourcePlayer.PlayerNumber} as {SourcePlayer.Card.CardName} " +
                   $"{SourcePlayer.Card.Effect.EffectName} Player {TargetPlayer.PlayerNumber}";
        }
    }
}