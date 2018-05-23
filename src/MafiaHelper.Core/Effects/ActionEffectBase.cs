namespace MafiaHelper.Core
{
    public abstract class ActionEffectBase : IActionEffect
    {
        public abstract string EffectName { get; }

        public virtual bool IsBlocking => false;

        public bool IsNeutralized { get; set; }
    }
}