using System;

namespace LoginSystemApp.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
            : base("Password cannot be empty and must be at least 6 characters long.") { }

        public InvalidPasswordException(string message)
            : base(message) { }
    }
}
