using Lanre.Module.Library.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using HtmlAgilityPack;

using Lanre.Module.Library.Application.Books.Dtos;
using Lanre.Module.Library.Domain;
using Lanre.Module.Library.Infrastructure.HostedServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Samples.Services;
using ScrapySharp.Extensions;
using ScrapySharp.Network;

using System;
using System.Reflection.Metadata;
using Lanre.Module.Library.Application.Books;

namespace Samples.Services;


public class AccumulatorBackgroundService : BackgroundService
{
    private readonly ILogger<AccumulatorBackgroundService> _logger;
    private readonly IBookAccumulatorQueue _queue;
    private readonly IServiceProvider _service;
    private readonly ImportBookFeature _importBookFeature;

    public AccumulatorBackgroundService(ILogger<AccumulatorBackgroundService> logger,
      IBookAccumulatorQueue queue,
      IServiceProvider service,
      ImportBookFeature importBookFeature)
    {
        _logger = logger;
        _queue = queue;
        _service = service;
        _importBookFeature = importBookFeature;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var bookMessage = await _queue.PullAsync(stoppingToken);

                _logger.LogInformation($"--- Processing import for {bookMessage.Url} requested by {bookMessage.UserId}");

                await _importBookFeature.Execute(bookMessage.Url, bookMessage.UserId, stoppingToken);

                _logger.LogInformation($"--- Process ended import for {bookMessage.Url} requested by {bookMessage.UserId}");

                //using var scope = _service.CreateScope();
                //var libraryContext = scope.ServiceProvider.GetService<LibraryContext>();

                //await repo.InsertRedirect(redirect);

                ////ScrapingBrowser browser = new ScrapingBrowser();
                ////var html = (await browser.NavigateToPageAsync(new Uri(bookMessage.Url))).Html;
                ////_logger.LogInformation($"--- Processing import book sleeping 20 s");

                ////Thread.Sleep(15000);
                ////_logger.LogInformation($"--- Processing import book wake up");

                ////var name = html.CssSelect("[data-testid='bookTitle']").FirstOrDefault()?.InnerText;
                ////var imageSrc = html.CssSelect(".BookPage__leftColumn .ResponsiveImage").FirstOrDefault()?.GetAttributeValue("src");
                ////var authors = html.CssSelect(".ContributorLink__name .ResponsiveImage").Select(x => x.InnerText).Distinct();
                ////var series = html.CssSelect(".BookPageTitleSection__title a").FirstOrDefault()?.GetAttributeValue("href");
                ////var description = html.CssSelect(".BookPageMetadataSection__description .Formatted").FirstOrDefault()?.InnerText?.Replace("\n", " ");
                ////var pages = html.CssSelect(".BookDetails .pagesFormat").FirstOrDefault()?.InnerText;
                ////var rating = html.CssSelect(".RatingStatistics__rating").FirstOrDefault()?.InnerText;

                ////var entity = new Book.Builder()
                ////   .SetName(name)
                ////   .SetUserId(bookMessage.UserId)
                ////   .SetAuthors(string.Join(",", authors))
                ////   .SetImageUrl(imageSrc)
                ////   .SetUrl(bookMessage.Url)
                ////   .SetSeries(series)
                ////   .SetSinopsis(description)
                ////   .SetPages(pages)
                ////   .SetRating(rating)
                ////   .Build();

                ////await libraryContext.Books.AddAsync(entity);

                ////await libraryContext.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                _logger.LogError($"Failure while processing queue {ex}");
            }
        }
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping Background Service");
        await base.StopAsync(cancellationToken);
    }
}
