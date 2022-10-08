using Microsoft.Extensions.Logging;
using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Services;

namespace Piro.FhirServer.Application.Decorators;

public class ResourceStoreLoggingDecorator : IResourceStoreService
{
    private readonly IResourceStoreService _resourceStoreService;
    private readonly ILogger<ResourceStoreLoggingDecorator> _logger;

    public ResourceStoreLoggingDecorator(ILogger<ResourceStoreLoggingDecorator> logger, 
        IResourceStoreService resourceStoreService)
    {
        _resourceStoreService = resourceStoreService;
        _logger = logger;
    }


    public async Task Add(ResourceStore resourceStore)
    { 
        _logger.LogInformation("Before Add");
        await _resourceStoreService.Add(resourceStore);
        _logger.LogInformation("After Add");
    }
}