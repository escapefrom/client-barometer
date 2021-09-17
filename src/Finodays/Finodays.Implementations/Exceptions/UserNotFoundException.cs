using System;

namespace Finodays.Implementations.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string UserId { get; }

        public UserNotFoundException(string userId, string message = "")
            : base(message)
        {
            UserId = userId;
        }
    }
}
