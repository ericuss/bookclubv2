using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;
using Lanre.Module.Library.Infrastructure.HostedServices;

namespace Samples.Services;

public interface IBookAccumulatorQueue
{
    ValueTask<ImportBookMessage> PullAsync(CancellationToken cancellationToken);
    ValueTask PushAsync([NotNull] ImportBookMessage book);
}

public class BookAccumulatorQueue : IBookAccumulatorQueue
{
    private readonly Channel<ImportBookMessage> _queue;
    private readonly ILogger<BookAccumulatorQueue> _logger;

    public BookAccumulatorQueue(ILogger<BookAccumulatorQueue> logger)
    {
        var opts = new BoundedChannelOptions(100) { FullMode = BoundedChannelFullMode.Wait };
        _queue = Channel.CreateBounded<ImportBookMessage>(opts);
        _logger = logger;
    }

    public async ValueTask PushAsync([NotNull] ImportBookMessage book)
    {
        await _queue.Writer.WriteAsync(book);
        _logger.LogInformation("Added Book to Queue");
    }

    public async ValueTask<ImportBookMessage> PullAsync(CancellationToken cancellationToken)
    {
        var result = await _queue.Reader.ReadAsync(cancellationToken);
        _logger.LogInformation("Removed Book from Queue");
        return result;
    }
}
