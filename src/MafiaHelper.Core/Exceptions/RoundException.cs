using System;
using System.Collections.Generic;

namespace MafiaHelper.Core.Exceptions
{
    public class RoundException : AggregateException
    {
        public RoundException(IEnumerable<Exception> innerExceptions)
            : base(innerExceptions)
        {
        }
    }
}