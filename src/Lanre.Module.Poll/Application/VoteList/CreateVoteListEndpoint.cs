namespace Lanre.Module.Poll.Application.VoteList;

using Lanre.Module.Poll.Application.VoteList.Dtos;
using Lanre.Module.Poll.Infrastructure.Database;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public static class CreateVoteListEndpoint
{
    public static async Task<IResult> Handle(
        [FromServices] IHttpContextAccessor contextAccessor,
        [FromServices] PollContext pollContext,
        [FromBody] CreateDto dto
    )
    {
        var userId = contextAccessor.HttpContext?.User?.Identity?.Name;

        if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(userId) || !dto.Books.Any())
        {
            return Results.BadRequest();
        }


        var entity = new Domain.VoteList.Builder()
           .SetName(dto.Name)
           .SetUserId(userId)
           .SetNumberOfVotes(dto.NumberOfVotes)
           .SetBookIds(dto.Books)
           .Build();

        pollContext.VoteLists.Add(entity);

        await pollContext.SaveChangesAsync();

        return Results.Ok(new
        {
            id = entity.Id,
        });
    }
}

