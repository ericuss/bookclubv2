namespace Lanre.Module.Poll.Application.VoteList;

using Lanre.Module.Poll.Application.VoteList.Dtos;
using Lanre.Module.Poll.Domain;

internal static class Mapper
{
    internal static VoteListDto MapTo(VoteList entity)
    {
        return new VoteListDto
        {
            Id = entity.Id,
            Name = entity.Name,
            UserId = entity.UserId,
        };
    }
}

