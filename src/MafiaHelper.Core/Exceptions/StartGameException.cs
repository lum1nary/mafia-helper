using System;
using System.Collections.Generic;

namespace MafiaHelper.Core.Exceptions
{
    public class StartGameException : AggregateException
    {
        public StartGameException(IEnumerable<Exception> inners) : base(inners)
        {
            
        }
    }
}