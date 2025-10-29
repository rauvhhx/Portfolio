using System;

namespace LoginSystemApp.Exceptions
{
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException()
            : base("Username cannot be empty and must be at least 3 characters long.") { }

        public InvalidUsernameException(string message)
            : base(message) { }
    }
}
