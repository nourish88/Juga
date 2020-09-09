using Microsoft.IdentityModel.Tokens;

namespace Framework.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreaterSigningCredentials(SecurityKey securityKey)
        {

        return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        }
    }
}
