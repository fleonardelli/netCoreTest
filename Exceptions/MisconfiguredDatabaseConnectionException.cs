using System;

namespace api.Exceptions
{
    public class MisconfiguredDatabaseConnectionException: Exception
    {
        public MisconfiguredDatabaseConnectionException(): base("Mysql was not configured for the current env")
        {

        }
    }
}