using System;

namespace Customer.Service.EventHandlers.EventHandler.Exceptions
{
    public class UserCommandException : Exception
    {
        public UserCommandException(string message) : base(message) { }
    }
}