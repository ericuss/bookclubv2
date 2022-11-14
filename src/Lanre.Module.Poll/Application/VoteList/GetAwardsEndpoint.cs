namespace Lanre.Module.Poll.Application.VoteList;
using Lanre.Module.Poll.Infrastructure.Database;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

public static class GetAwardsEndpoint
{
    public static async Task<IResult> Handle(
        [FromServices] PollContext pollContext,
        [FromRoute] Guid id
    )
    {
        var entity = await pollContext
                            .VoteLists
                            .Include( x=> x.Votes)
                            .Include( x=> x.Books)
                                .ThenInclude( x=> x.Book)
                            .FirstAsync(x => x.Id == id);

        return Results.Ok(new 
        {
            Id = entity.Id,
            Name = entity.Name,
            NumberOfVotes = entity.NumberOfVotes,
            UserId = entity.UserId,
            Books = entity.Books.Select(Mapper.MapTo).ToList(),
            NumberOfBooks = entity.Books.Count(),
            Created = entity.Created,
            Readed = entity.Votes.SelectMany(x => x.Readed),
            Blocked = entity.Votes.SelectMany(x => x.Blocked),
            Voted = entity.Votes.SelectMany(x => x.Voted),
        });
    }

}

