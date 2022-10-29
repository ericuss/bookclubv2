namespace Lanre.Module.Library.Application.Books;

using Lanre.Infrastructure.Dtos;
using Lanre.Module.Library.Infrastructure.Database;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public static class GetByIdBookEndpoint
{
    public static async Task<IResult> Handle(
        [FromServices] LibraryContext libraryContext,
        [FromBody] GetByIdDto dto
    )
    {
        var entity = await libraryContext.Books.FirstAsync(x => x.Id == dto.Id);
        return Results.Ok(Mapper.MapTo(entity));
    }
}

