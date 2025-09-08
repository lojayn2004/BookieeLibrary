namespace Shared.Dtos.Authorization
{
    public class JwtOption
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string SecretKey { get; set; }   

        public int ExpirationsDays { get; set; }
    }
}
