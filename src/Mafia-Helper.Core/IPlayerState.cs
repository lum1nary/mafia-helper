using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public interface IPlayerState
    {
        IReadOnlyList<IActionEffect> Effects { get; }

        void ApplyEffect(IActionEffect effect);

        void Refresh();
    }
}