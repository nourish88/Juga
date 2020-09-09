using System;

namespace Framework.Utilities.Security.JWT
{
    public   class AccessToken
 {
     public string Token { get; set; }
     public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
     
 }
}
