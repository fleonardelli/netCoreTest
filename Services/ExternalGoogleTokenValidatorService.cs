using api.Exceptions;

namespace api.Services
{
    public class ExternalGoogleTokenValidatorService : IExternalTokenValidator
    {
        public bool validateToken(string token)
        {
            //here we should check with an external provider - for example Google SSO
            //that the externalToken received is a correct token generated from Google.
            var valid = true;
            if (!valid) {
                throw (new InvalidExternalTokenException());
            }

            return valid;
        }
    }
}