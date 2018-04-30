using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public class EffectCollection : List<IActionEffect>
    {
        public bool ContainsEffect(string effectName)
        {
            return Find(i => i.EffectName == effectName) != null;
        }

        public bool ContainsActualEffect(string effectName)
        {
            return Find(i => i.EffectName == effectName && !i.IsNeutralized) != null;
        }

        public int CountEffects(string effectName)
        {
            return FindAll(i => i.EffectName == effectName && !i.IsNeutralized).Count;
        }
    }
}