using System.Linq;

namespace MafiaHelper.Core.Rules
{
    public class ClassicMafiaRules : IMafiaRules
    {
        public bool IsGameComplete(IMafiaGame game)
        {
            throw new System.NotImplementedException();
        }

        public bool IsPlayerCanContinue(IMafiaPlayer player)
        {
            return !player.State.Effects.Any(i => i.EffectName == "killed" || i.EffectName == "voted");
        }

        public void Initialize(IMafiaGame game)
        {
            throw new System.NotImplementedException();
        }
    }
}