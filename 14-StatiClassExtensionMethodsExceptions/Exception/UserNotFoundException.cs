using System;

namespace LoginSystemApp.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
            : base("User not found.") { }

        public UserNotFoundException(string username)
            : base($"User '{username}' not found.") { }
    }
}
