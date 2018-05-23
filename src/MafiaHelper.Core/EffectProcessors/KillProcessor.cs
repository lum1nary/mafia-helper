using System.Linq;

namespace MafiaHelper.Core.EffectProcessors
{
    public class KillProcessor : EffectProcessorBase
    {
        public override string ProcessEffectName => ActionEffectConstants.Killed;

        public override void Process(IRound round)
        {
            var actions = round.Actions.Where(i => i.Team.Effect.EffectName == ProcessEffectName).ToList();
            foreach (var action in actions)
            {
                if (!action.TargetPlayer.State.Effects.ContainsEffect(ActionEffectConstants.Healed) ||
                    !action.TargetPlayer.State.Effects.ContainsEffect(ActionEffectConstants.Fucked))
                    continue;

                action.Team.Effect.IsNeutralized = true;
                RaiseNeutralized(action.Team, action.TargetPlayer);
            }
        }
    }
}