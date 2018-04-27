using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public interface IPlayerState
    {
        IReadOnlyList<IMafiaCardEffect> Effects { get; }

        void ApplyEffect(IMafiaCardEffect effect);
    }
}