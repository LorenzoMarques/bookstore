namespace bookstore
{
    public class Configuration
    {
        public static string PrivateJwtKey { get; set; } = Environment.GetEnvironmentVariable("PrivateJwtKey") ?? string.Empty;
        public static string Issuer { get; set; } = Environment.GetEnvironmentVariable("Issuer") ?? string.Empty;
        public static string Audience { get; set; } = Environment.GetEnvironmentVariable("Audience") ?? string.Empty;

    }
}