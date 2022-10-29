namespace Lanre.Module.Library.Application.Books;

using Lanre.Module.Library.Infrastructure.Database;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public static class GetAllBookEndpoint
{
    public static async Task<IResult> Handle(
        [FromServices] LibraryContext libraryContext
    )
    {
        var entities = await libraryContext.Books.ToListAsync();
        return Results.Ok(entities.Select(Mapper.MapTo));
    }
}

