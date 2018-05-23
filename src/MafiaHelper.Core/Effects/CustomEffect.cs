namespace MafiaHelper.Core
{
    public class CustomEffect : ActionEffectBase
    {
        public override string EffectName { get; }
        public override bool IsBlocking { get; }

        public CustomEffect(string effect, bool isBlocking)
        {
            EffectName = effect;
            IsBlocking = isBlocking;
        }
    }
}