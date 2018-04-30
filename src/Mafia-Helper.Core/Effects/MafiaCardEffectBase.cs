using System;

namespace MafiaHelper.Core
{
    public abstract class ActionEffectBase : IActionEffect
    {
        protected ActionEffectBase(string effectName)
        {
            _effectName = effectName;
            if (Enum.TryParse(_effectName, out ActionEffectName def))
            {
                DefaultEffectName = def;
            }
        }

        private readonly string _effectName;
        public string EffectName => DefaultEffectName != null ? DefaultEffectName.ToString() : _effectName;

        public ActionEffectName? DefaultEffectName { get; }
    }
}