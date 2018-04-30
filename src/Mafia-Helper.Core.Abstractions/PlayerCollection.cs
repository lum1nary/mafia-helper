using System.Collections.Generic;
using System.Linq;

namespace MafiaHelper.Core
{
    public class PlayerCollection : List<IMafiaPlayer>
    {
        public bool IsCanChoose => this.Any(i => i.State.IsCanChoose);

        public PlayerCollection(IEnumerable<IMafiaPlayer> items) : base(items)
        {
        }
    }
}