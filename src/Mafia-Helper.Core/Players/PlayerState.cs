using System;
using System.Collections.Generic;

namespace MafiaHelper.Core.Players
{
    public class PlayerState : IPlayerState
    {
        private readonly List<IActionEffect> _effects = new List<IActionEffect>();
        public IReadOnlyList<IActionEffect> Effects => _effects;
        public void ApplyEffect(IActionEffect effect)
        {
            if(effect == null)
                throw new ArgumentNullException();

            _effects.Add(effect);
        }

        public void Refresh()
        {
            _effects.Clear();
        }
    }
}