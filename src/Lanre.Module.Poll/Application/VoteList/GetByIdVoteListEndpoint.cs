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
        [FromBody] GetByIdDto dto
    )
    {
        var entity = await pollContext.VoteLists.FirstAsync(x => x.Id == dto.Id);

        return Results.Ok(Mapper.MapTo(entity));
    }
}

