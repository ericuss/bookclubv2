namespace Lanre.Module.Poll.Application.VoteList;

using Lanre.Module.Poll.Application.VoteList.Dtos;
using Lanre.Module.Poll.Infrastructure.Database;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class VoteEndpoint
{
    public static async Task<IResult> Handle(
        [FromServices] IHttpContextAccessor contextAccessor,
        [FromServices] ILogger<VoteEndpoint> logs,
        [FromServices] PollContext pollContext,
        [FromBody] VoteDto dto,
        CancellationToken cancellationToken
    )
    {
        var userId = contextAccessor.HttpContext?.User?.Identity?.Name;

        if (string.IsNullOrWhiteSpace(dto.Id) || !Guid.TryParse(dto.Id, out var  votelistId)|| !dto.ReadedIds.Any())
        {
            logs.LogWarning("Validation failed");
            return Results.BadRequest();
        }
        var voteList = await pollContext.VoteLists.FirstOrDefaultAsync(x => x.Id == votelistId, cancellationToken);

        if (voteList == null)
        {
            logs.LogWarning("Volte list not found");
            return Results.BadRequest();
        }

        if (voteList.NumberOfVotes <= dto.VotedIds.Count)
        {
            logs.LogWarning($"voted {dto.VotedIds.Count} of {voteList.NumberOfVotes}");
            return Results.BadRequest();
        }

        var entity = new Domain.Vote.Builder()
            .SetIds(votelistId, userId)
            .SetVoted(dto.VotedIds)
            .SetReaded(dto.ReadedIds)
            .SetBlocked(dto.BlockedIds)
           .Build();

        pollContext.Votes.Add(entity);

        await pollContext.SaveChangesAsync();

        return Results.Ok(new
        {
            votelistId,
            userId
        });
    }
}

