using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public class TeamCollection : List<ITeam>
    {
        public TeamCollection(IEnumerable<ITeam> items) : base(items)
        {
        }

        public ITeam this[string name]
        {
            get { return Find(i => i.TeamName == name); }
        }
    }
}