using System;

namespace LoginSystemApp.Exceptions
{
    public class AccountLockedException : Exception
    {
        public AccountLockedException()
            : base("Account has been locked due to multiple failed login attempts.") { }
    }
}
