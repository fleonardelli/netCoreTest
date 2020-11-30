using System;

namespace api.Exceptions
{
    public class UserRoleNotFoundException : Exception
    {
        public UserRoleNotFoundException() { }
        public UserRoleNotFoundException(string message) : base(message) { }

    }
}