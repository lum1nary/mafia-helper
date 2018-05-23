namespace MafiaHelper.Core
{
    public class KillEffect : ActionEffectBase
    {
        public override string EffectName => ActionEffectConstants.Killed;

        public override bool IsBlocking => true;
    }
}