namespace Framework.Utilities.Security.JWT
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AcccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
