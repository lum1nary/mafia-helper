using System;
using System.Collections.Generic;

namespace MafiaHelper.Core.Players
{
    public class PlayerState : IPlayerState
    {
        private readonly List<IMafiaCardEffect> _effects = new List<IMafiaCardEffect>();
        public IReadOnlyList<IMafiaCardEffect> Effects => _effects;
        public void ApplyEffect(IMafiaCardEffect effect)
        {
            if(effect == null)
                throw new ArgumentNullException();

            _effects.Add(effect);
        }
    }
}