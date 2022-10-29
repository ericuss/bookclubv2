namespace Lanre.Module.Library.Application.Books.Dtos;

public class BookDto
{
    public Guid? Id { get; set; }
    
    public string? Name { get; set; }

    public string? Series { get; set; }

    public string? Authors { get; set; }

    public string? Rating { get; set; }

    public string? Sinopsis { get; set; }

    public string? ImageUrl { get; set; }

    public string? Url { get; set; }

    public string? Pages { get; set; }

    public string? UserId { get; set; }
}
