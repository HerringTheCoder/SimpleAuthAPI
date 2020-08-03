namespace SimpleAuthAPI.Configuration
{
    public class JwtTokenSettings
    {
        public string SecretKey { get; set; }

        public string Audience { get; set; }

        public string Issuer { get; set; }

        public int ExpiryTimeInSeconds { get; set; }
    }
}
