namespace bookstore
{
    public class Configuration
    {
        public static string PrivateJwtKey { get; set; } = Environment.GetEnvironmentVariable("PrivateJwtKey") ?? string.Empty;
    }
}