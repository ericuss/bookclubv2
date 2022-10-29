namespace Lanre.Module.Poll.Application.VoteList;

using Lanre.Module.Poll.Application.VoteList.Dtos;
using Lanre.Module.Poll.Infrastructure.Database;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public static class CreateVoteListEndpoint
{
    public static async Task<IResult> Handle(
        [FromServices] PollContext pollContext,
        [FromBody] CreateDto dto
    )
    {
        var entity = new Domain.VoteList.Builder()
           .SetName(dto.Name)
           .SetUserId(dto.UserId)
           .Build();

        pollContext.VoteLists.Add(entity);

        await pollContext.SaveChangesAsync();

        return Results.Ok(new
        {
            id = entity.Id,
        });
    }
}

