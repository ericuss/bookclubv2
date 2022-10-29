namespace Lanre.Module.Library.Application.Books;

using HtmlAgilityPack;

using Lanre.Module.Library.Application.Books.Dtos;
using Lanre.Module.Library.Domain;
using Lanre.Module.Library.Infrastructure.Database;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ScrapySharp.Extensions;
using ScrapySharp.Network;

using System;
using System.Reflection.Metadata;

public static class CreateBookEndpoint
{
    public static async Task<IResult> Handle(
        [FromServices] IHttpContextAccessor contextAccessor,
        [FromServices] LibraryContext libraryContext,
        [FromBody] CreateBookDto dto
    )
    {
        // import
        ScrapingBrowser browser = new ScrapingBrowser();
        var html = (await browser.NavigateToPageAsync(new Uri(dto.Url))).Html;

        Thread.Sleep(15000);

        var name = html.CssSelect("[data-testid='bookTitle']").FirstOrDefault()?.InnerText;
        var imageSrc = html.CssSelect(".BookPage__leftColumn .ResponsiveImage").FirstOrDefault()?.GetAttributeValue("src");
        var authors = html.CssSelect(".ContributorLink__name .ResponsiveImage").Select(x => x.InnerText).Distinct();
        var series = html.CssSelect(".BookPageTitleSection__title a").FirstOrDefault()?.GetAttributeValue("href");
        var description = html.CssSelect(".BookPageMetadataSection__description .Formatted").FirstOrDefault()?.InnerText?.Replace("\n", " ");
        var pages = html.CssSelect(".BookDetails .pagesFormat").FirstOrDefault()?.InnerText;
        var rating = html.CssSelect(".RatingStatistics__rating").FirstOrDefault()?.InnerText;
        var userId = contextAccessor.HttpContext?.User?.Identity?.Name;
        var entity = new Book.Builder()
           .SetName(name)
           .SetUserId(userId)
           .SetAuthors(string.Join(",", authors))
           .SetImageUrl(imageSrc)
           .SetUrl(dto.Url)
           .SetSeries(series)
           .SetSinopsis(description)
           .SetPages(pages)
           .SetRating(rating)
           .Build();

        libraryContext.Books.Add(entity);

        await libraryContext.SaveChangesAsync();

        return Results.Ok(new
        {
            id = entity.Id,
        });
    }
}

