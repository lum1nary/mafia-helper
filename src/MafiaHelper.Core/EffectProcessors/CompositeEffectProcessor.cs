using System;
using System.Collections.Generic;
using System.Linq;

namespace MafiaHelper.Core.EffectProcessors
{
    public class CompositeEffectProcessor : IEffectProcessor
    {
        public event EventHandler<INeutralizeAction> EffectNeutralized
        {
            add { foreach (var resolver in _processors) resolver.EffectNeutralized += value; }
            remove { foreach (var resolver in _processors) resolver.EffectNeutralized -= value; }
        }

        private readonly IEnumerable<IEffectProcessor> _processors;

        public CompositeEffectProcessor(IEnumerable<IEffectProcessor> processors)
        {
            _processors = processors;
        }

        public CompositeEffectProcessor(params IEffectProcessor[] processors)
        {
            _processors = processors;
        }

        public string ProcessEffectName => string.Empty;

        public void Process(IRound round)
        {
            var orderedEffects = round.Actions.OrderBy(i => i.Team.Priority).Select(i => i.Team.Effect.EffectName);

            foreach (var effect in orderedEffects)
            {
                var processors = _processors.Where(p => p.ProcessEffectName == effect);

                foreach (var processor in processors)
                    processor.Process(round);
            }
        }
    }
}