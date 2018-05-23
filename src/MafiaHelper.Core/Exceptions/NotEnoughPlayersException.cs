using System;

namespace MafiaHelper.Core.Exceptions
{
    public class NotEnoughPlayersException : Exception
    {
        public int Requeried { get; }
        public int Actual { get; }

        public NotEnoughPlayersException(int requeried, int actual)
         : base($"Not Enough players to start game (got {actual}, need {requeried})")
        {
            Requeried = requeried;
            Actual = actual;
        }

    }
}