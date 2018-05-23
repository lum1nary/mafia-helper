using System;
using System.Linq;

namespace MafiaHelper.Core
{
    public class PlayerState : IPlayerState
    {
        private readonly EffectCollection _effects = new EffectCollection();
        public bool IsCanChoose => _effects.Any(e => e.IsBlocking);
        public bool IsCanVote => !_effects.ContainsEffect(ActionEffectConstants.VoteBan);
        public EffectCollection Effects => _effects;
        public void Apply(IActionEffect effect)
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