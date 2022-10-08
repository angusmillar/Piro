using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Services;

namespace Piro.FhirServer.Application.Decorators;

public class ResourceStoreTimerDecorator : IResourceStoreService
{
    private readonly IResourceStoreService _resourceStoreService;
    private readonly ILogger<ResourceStoreTimerDecorator> _logger;

    public ResourceStoreTimerDecorator(ILogger<ResourceStoreTimerDecorator> logger, 
        IResourceStoreService resourceStoreService)
    {
        _resourceStoreService = resourceStoreService;
        _logger = logger;
    }


    public async Task Add(ResourceStore resourceStore)
    {
        var timer = new Stopwatch();
        timer.Start();
        await _resourceStoreService.Add(resourceStore);
        timer.Stop();
        _logger.LogInformation("Time taken: {TimeTaken}", timer.Elapsed.ToString(@"m\:ss\.fff"));
    }
}