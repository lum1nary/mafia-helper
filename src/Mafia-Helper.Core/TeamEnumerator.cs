using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MafiaHelper.Core
{
    public class TeamEnumerator : IEnumerable<IMafiaTeam>, IEnumerator<IMafiaTeam>
    {
        private readonly LinkedList<IMafiaTeam> _prioritizedTeams;

        private LinkedListNode<IMafiaTeam> _current;

        public TeamEnumerator(IEnumerable<IMafiaTeam> teams)
        {
            _prioritizedTeams = new LinkedList<IMafiaTeam>(teams.OrderBy(i => i.Priority));
        }

        public IEnumerator<IMafiaTeam> GetEnumerator()
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

        public IMafiaTeam Current => _current.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _prioritizedTeams.Clear();
        }
    }
}