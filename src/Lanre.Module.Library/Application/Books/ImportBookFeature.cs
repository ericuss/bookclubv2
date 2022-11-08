namespace Lanre.Module.Library.Application.Books;

using HtmlAgilityPack;
using Lanre.Module.Library.Domain;
using Lanre.Module.Library.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;

public class ImportBookFeature
{
    private readonly ILogger<ImportBookFeature> _logger;
    private readonly IServiceProvider _service;
    private readonly ScrapingBrowser _browser;

    public ImportBookFeature(
        ILogger<ImportBookFeature> logger,
        IServiceProvider service
        )
    {
        _logger = logger;
        _service = service;
        _browser = new ScrapingBrowser();
    }

    public async Task Execute(string url, string userId, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"--- Import book stating ");

        using var scope = _service.CreateScope();
        var libraryContext = scope.ServiceProvider.GetService<LibraryContext>();
        var html = (await _browser.NavigateToPageAsync(new Uri(url))).Html;
        _logger.LogInformation($"--- Import book sleeping 20 s");

        Thread.Sleep(20000);

        _logger.LogInformation($"--- Import book wake up");
        var name = html.CssSelect("[data-testid='bookTitle']").FirstOrDefault()?.InnerText;
        Book entity;
        if (!string.IsNullOrEmpty(name))
        {
            entity = ImportA(html, userId, url);
        }
        else
        {
            entity = ImportB(html, userId, url);
        }


        await libraryContext.Books.AddAsync(entity, cancellationToken);

        await libraryContext.SaveChangesAsync(cancellationToken);


        _logger.LogInformation($"--- Import book end");
    }

    private Book ImportA(HtmlNode html, string userId, string url)
    {
        var name = html.CssSelect("[data-testid='bookTitle']").FirstOrDefault()?.InnerText;
        var imageSrc = html.CssSelect(".BookPage__leftColumn .ResponsiveImage").FirstOrDefault()?.GetAttributeValue("src");
        var authors = html.CssSelect(".ContributorLink__name .ResponsiveImage").Select(x => x.InnerText).Distinct();
        var series = html.CssSelect(".BookPageTitleSection__title a").FirstOrDefault()?.GetAttributeValue("href");
        var description = html.CssSelect(".BookPageMetadataSection__description .Formatted").FirstOrDefault()?.InnerText?.Replace("\n", " ");
        var pages = html.CssSelect(".BookDetails .pagesFormat").FirstOrDefault()?.InnerText;
        var rating = html.CssSelect(".RatingStatistics__rating").FirstOrDefault()?.InnerText;

        var entity = new Book.Builder()
           .SetName(name)
           .SetUserId(userId)
           .SetAuthors(string.Join(",", authors))
           .SetImageUrl(imageSrc)
           .SetUrl(url)
           .SetSeries(series)
           .SetSinopsis(description)
           .SetPages(pages)
           .SetRating(rating)
           .Build();

        return entity;
    }

    private Book ImportB(HtmlNode html, string userId, string url)
    {
        var name = html.CssSelect("#bookTitle").FirstOrDefault()?.InnerText;
        var imageSrc = html.CssSelect("#coverImage").FirstOrDefault()?.GetAttributeValue("src");
        var authors = html.CssSelect(".authorName").Select(x => x.InnerText).Distinct();
        var series = html.CssSelect("#bookSeries a").FirstOrDefault()?.GetAttributeValue("href");
        var description = html.CssSelect("#description").FirstOrDefault()?.InnerText?.Replace("\n", " ");
        var pages = html.CssSelect("#details").FirstOrDefault()?.InnerText;
        var rating = html.CssSelect("[itemprop='ratingValue']").FirstOrDefault()?.InnerText;

        var entity = new Book.Builder()
           .SetName(name)
           .SetUserId(userId)
           .SetAuthors(string.Join(",", authors))
           .SetImageUrl(imageSrc)
           .SetUrl(url)
           .SetSeries(series)
           .SetSinopsis(description)
           .SetPages(pages)
           .SetRating(rating)
           .Build();

        return entity;
    }

}

