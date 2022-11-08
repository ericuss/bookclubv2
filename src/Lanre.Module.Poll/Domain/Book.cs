using Lanre.Infrastructure.Domain;

namespace Lanre.Module.Poll.Domain;

public class Book:IBook
{
    public Guid Id { get; internal set; }

    public string Name { get; internal set; }

    public string? Series { get; internal set; }

    public string? Authors { get; internal set; }

    public string? Rating { get; internal set; }

    public string? Sinopsis { get; internal set; }

    public string? ImageUrl { get; internal set; }

    public string? Url { get; internal set; }

    public string? Pages { get; internal set; }

    public string UserId { get; internal set; }
}