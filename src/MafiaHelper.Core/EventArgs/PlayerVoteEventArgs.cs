namespace MafiaHelper.Core
{
    public class PlayerVoteEventArgs : System.EventArgs, IVoteAction
    {
        public IMafiaPlayer SourcePlayer { get; }

        public IMafiaPlayer TargetPlayer { get; }

        public PlayerVoteEventArgs(IMafiaPlayer sourcePlayer, IMafiaPlayer targetPlayer)
        {
            SourcePlayer = sourcePlayer;
            TargetPlayer = targetPlayer;
        }

        public override string ToString()
        {
            return $"Player #{SourcePlayer.PlayerNumber} voted for player #{TargetPlayer.PlayerNumber}";
        }
    }
}