using System;

namespace MafiaHelper.Core.Exceptions
{
    public class NoGameReasonException : Exception
    {
        public NoGameReasonException(string additionalMessage) 
            : base("No Reason to play " + additionalMessage)
        {
            
        }
    }
}