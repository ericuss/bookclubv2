namespace Lanre.Infrastructure.Domain
{
    public interface IBook
    {
        string? Authors { get; }
        Guid Id { get; }
        string? ImageUrl { get; }
        string Name { get; }
        string? Pages { get; }
        string? Rating { get; }
        string? Series { get; }
        string? Sinopsis { get; }
        string? Url { get; }
        string UserId { get; }
    }
}