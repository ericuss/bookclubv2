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
            NumberOfVotes = entity.NumberOfVotes,
            UserId = entity.UserId,
        };
    }

    internal static VoteListWithBooksDto MapToVoteListWithBooks(VoteList entity)
    {
        return new VoteListWithBooksDto
        {
            Id = entity.Id,
            Name = entity.Name,
            NumberOfVotes = entity.NumberOfVotes,
            UserId = entity.UserId,
            Books = entity.Books.Select(MapTo).ToList(),
        };
    }

    internal static BookDto MapTo(BookOfVoteList entity)
    {
        return new BookDto
        {
            Id = entity.Book.Id,
            Name = entity.Book.Name,
            Series = entity.Book.Series,
            Authors = entity.Book.Authors,
            Rating = entity.Book.Rating,
            Sinopsis = entity.Book.Sinopsis,
            ImageUrl = entity.Book.ImageUrl,
            Url = entity.Book.Url,
            Pages = entity.Book.Pages,
            UserId = entity.Book.UserId,
            Votes = entity.Votes,
            BloquedBy = entity.BloquedBy,
            ReadedBy = entity.ReadedBy,
        };
    }
}

