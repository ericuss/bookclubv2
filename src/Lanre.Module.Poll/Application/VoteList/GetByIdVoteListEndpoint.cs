namespace Lanre.Module.Poll.Application.VoteList;

using Lanre.Infrastructure.Dtos;
using Lanre.Module.Poll.Infrastructure.Database;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public static class GetByIdVoteListEndpoint
{
    public static async Task<IResult> Handle(
        [FromServices] PollContext pollContext,
        [FromRoute] Guid id
    )
    {
        var entity = await pollContext
                            .VoteLists
                            .Include( x=> x.Books)
                                .ThenInclude( x=> x.Book)
                            .FirstAsync(x => x.Id == id);

        return Results.Ok(Mapper.MapToVoteListWithBooks(entity));
    }
}

