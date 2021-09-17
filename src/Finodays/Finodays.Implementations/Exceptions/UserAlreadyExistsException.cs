using System;
using AutoMapper;

namespace Finodays.Implementations.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public string SourceId { get; }

        public UserAlreadyExistsException(string sourceId, string message = "")
            : base(message)
        {
            SourceId = sourceId;
        }
    }
}
