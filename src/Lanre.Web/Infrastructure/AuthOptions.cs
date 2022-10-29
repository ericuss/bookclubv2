namespace Lanre.Web
{
    public class AuthOptions
    {
        public static string Key = "Auth0";
        public string Domain { get; set; }
        public string Audience { get; set; }
        public string ClientId { get; set; }
    }
}