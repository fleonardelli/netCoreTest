using System;

namespace api.Exceptions
{
    public class MisconfiguredDatabaseConnection: Exception
    {
        public MisconfiguredDatabaseConnection(): base("Mysql was not configured for the current env")
        {

        }
    }
}