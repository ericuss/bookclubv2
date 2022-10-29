namespace Lanre.Module.Library.Application.Books;

using Lanre.Module.Library.Domain;
using Lanre.Module.Library.Application.Books.Dtos;

internal static class Mapper
{
    internal static BookDto MapTo(Book entity)
    {
        return new BookDto
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}

