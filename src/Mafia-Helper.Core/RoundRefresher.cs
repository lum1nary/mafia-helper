using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public class RoundRefresher : List<IRefreshable>, IRefreshable
    {
        public void Refresh()
        {
            foreach (var refreshable in this)
            {
                refreshable.Refresh();
            }
        }
    }
}