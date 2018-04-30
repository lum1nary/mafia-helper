using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MafiaHelper.Core
{
    public class TeamEnumerator : IEnumerable<ITeam>, IEnumerator<ITeam>
    {
        private readonly LinkedList<ITeam> _prioritizedTeams;

        private LinkedListNode<ITeam> _current;

        public TeamEnumerator(IEnumerable<ITeam> teams)
        {
            _prioritizedTeams = new LinkedList<ITeam>(teams.OrderBy(i => i.Priority));
        }

        public IEnumerator<ITeam> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            if (_prioritizedTeams.First.Value == null)
                return false;

            if (_current != null)
                return (_current = _current.Next) != null;

            _current = _prioritizedTeams.First;
            return true;
        }

        public void Reset()
        {
            _current = null;
        }

        public ITeam Current => _current.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _prioritizedTeams.Clear();
        }
    }
}