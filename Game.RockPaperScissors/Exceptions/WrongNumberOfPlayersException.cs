using System;

namespace Game.RockPaperScissors.Exceptions
{
    public class WrongNumberOfPlayersException : Exception
    {
        public WrongNumberOfPlayersException(string exceptionMessage)
            : base(exceptionMessage)
        {
        }
    }
}