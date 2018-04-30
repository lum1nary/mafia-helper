using System;

namespace MafiaHelper.Core
{
    public class PlayerChooseEventArgs : EventArgs, IChooseAction
    {
        public PlayerChooseEventArgs(ITeam team, IMafiaPlayer targetPlayer)
        {
            Team = team;
            TargetPlayer = targetPlayer;
        }

        public ITeam Team { get; }

        public IMafiaPlayer TargetPlayer { get; }

        public override string ToString()
        {
            return $"[{Team.TeamName}] {Team.Effect.EffectName} => [{TargetPlayer}]";
        }
    }
}