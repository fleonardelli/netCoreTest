namespace api.Exceptions
{
    public class UserNotFoundException : System.Exception
    {
        public UserNotFoundException(): base("The user was is not registered in the system")
        {

        }
    }
}