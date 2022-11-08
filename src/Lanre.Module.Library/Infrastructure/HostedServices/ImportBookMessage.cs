namespace Lanre.Module.Library.Infrastructure.HostedServices;

public class ImportBookMessage
{
    public ImportBookMessage(string url, string userId)
    {
        Url = url;
        UserId = userId;
    }

    public string Url { get; set; }

    public string UserId { get; set; }
}
