namespace Lanre.Module.Library.Application.Books;

using Lanre.Module.Library.Application.Books.Dtos;
using Lanre.Module.Library.Infrastructure.Database;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public static class DeleteBookEndpoint
{
    public static async Task<IResult> Handle(
        [FromServices] LibraryContext libraryContext,
        [FromBody] UpdateBookDto dto
    )
    {
        var entity = await libraryContext.Books.FirstAsync(x => x.Id == dto.Id);
        libraryContext.Books.Remove(entity);

        await libraryContext.SaveChangesAsync();

        return Results.Ok(new
        {
            id = entity.Id,
        });
    }
}

