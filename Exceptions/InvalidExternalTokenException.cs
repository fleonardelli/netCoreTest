using System;

namespace api.Exceptions
{
    public class InvalidExternalTokenException : Exception
    {
         public InvalidExternalTokenException(): base("The 3rd party token provided is not valid")
        {

        }
    }
}