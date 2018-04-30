using System;

namespace MafiaHelper.Core.Exceptions
{
    public class SelfChoiceException<T> : Exception
    {
        public T SelfChoosed { get; }

        public SelfChoiceException(T selfChoosed) : base("Action can't be applited to itSelf")
        {
            SelfChoosed = selfChoosed;
        }
    }
}