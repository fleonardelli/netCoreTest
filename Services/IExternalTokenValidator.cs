namespace api.Services
{
    public interface IExternalTokenValidator
    {
         public bool validateToken(string token);
    }
}