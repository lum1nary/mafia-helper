namespace MafiaHelper.Core.EventArgs
{
    public class PlayerChooseEventArgs : System.EventArgs
    {
        public PlayerChooseEventArgs(IMafiaTeam team, IMafiaPlayer targetPlayer)
        {
            Team = team;
            TargetPlayer = targetPlayer;
        }

        public IMafiaTeam Team { get; }

        public IMafiaPlayer TargetPlayer { get; }

        public override string ToString()
        {
            return $"{Team.TeamName} {Team.Effect.EffectName} Player {TargetPlayer.PlayerNumber}";
        }
    }
}