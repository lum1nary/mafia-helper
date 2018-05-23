using System;

namespace MafiaHelper.Core
{
    public interface IEffectProcessor
    {
        event EventHandler<INeutralizeAction> EffectNeutralized;

        string ProcessEffectName { get; }

        void Process(IRound round);
    }
}