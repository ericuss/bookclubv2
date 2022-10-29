namespace Lanre.Module.Library.Application.Books;

using Lanre.Module.Library.Application.Books.Dtos;
using Lanre.Module.Library.Infrastructure.Database;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public static class UpdateBookEndpoint
{
    public static async Task<IResult> Handle(
        [FromServices] LibraryContext libraryContext,
        [FromBody] UpdateBookDto dto
    )
    {
        var entity = await libraryContext.Books.FirstAsync(x => x.Id == dto.Id);
        entity.SetName(dto.Name);
        libraryContext.Books.Update(entity);

        await libraryContext.SaveChangesAsync();

        return Results.Ok(new
        {
            id = entity.Id,
        });
    }
}

