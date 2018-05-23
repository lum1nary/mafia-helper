using System;

namespace MafiaHelper.Core.EffectProcessors
{
    public abstract class EffectProcessorBase : IEffectProcessor
    {
        public event EventHandler<INeutralizeAction> EffectNeutralized;

        public abstract string ProcessEffectName { get; }
        public abstract void Process(IRound round);

        protected void RaiseNeutralized(ITeam fromTeam, IMafiaPlayer toPlayer)
        {
            EffectNeutralized?.Invoke(this, new PlayerEffectNeutralizeEventArgs(fromTeam, toPlayer));
        }
    }
}