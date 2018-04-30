namespace MafiaHelper.Core
{
    public class PlayerEffectNeutralizeEventArgs : PlayerChooseEventArgs, INeutralizeAction
    {
        public IActionEffect NeutralizedEffect => Team.Effect;

        public PlayerEffectNeutralizeEventArgs(
            ITeam team,
            IMafiaPlayer targetPlayer)
            : base(team, targetPlayer)
        {
        }

        public override string ToString()
        {
            return $"{TargetPlayer} applyed {NeutralizedEffect.EffectName} effect was neutralized by {Team}";
        }
    }
}