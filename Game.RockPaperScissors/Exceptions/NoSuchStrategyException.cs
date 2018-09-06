using System;

namespace Game.RockPaperScissors.Exceptions
{
    public class NoSuchStrategyException : Exception
    {
        public NoSuchStrategyException(string exceptionMessage)
            : base(exceptionMessage)
        {
        }
    }
}