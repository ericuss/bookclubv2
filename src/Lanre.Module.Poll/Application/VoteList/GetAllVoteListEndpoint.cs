namespace Lanre.Module.Poll.Application.VoteList;
using Lanre.Module.Poll.Infrastructure.Database;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public static class GetAllVoteListEndpoint
{
    public static async Task<IResult> Handle(
        [FromServices] PollContext pollContext
    )
    {
        var entities = await pollContext
                                .VoteLists
                                .Include(x => x.Books)
                                .OrderByDescending(x => x.Created)
                                .ToListAsync();

        return Results.Ok(entities.Select(Mapper.MapTo));
    }
}

