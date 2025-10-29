using System;

namespace LoginSystemApp.Exceptions
{
    public class IncorrectPasswordException : Exception
    {
        public int AttemptsLeft { get; }

        public IncorrectPasswordException(int attemptsLeft)
            : base($"Incorrect password. Attempts left: {attemptsLeft}")
        {
            AttemptsLeft = attemptsLeft;
        }
    }
}
