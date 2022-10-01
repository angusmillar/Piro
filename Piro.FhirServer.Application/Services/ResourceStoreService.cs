using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Domain.Repositories;

namespace Piro.FhirServer.Application.Services;

public class ResourceStoreService : IResourceStoreService
{
    private readonly IResourceStoreAdd _resourceStoreAdd;

    public ResourceStoreService(IResourceStoreAdd resourceStoreAdd)
    {
        _resourceStoreAdd = resourceStoreAdd;
    }

    public void Add(ResourceStore resourceStore)
    {
        _resourceStoreAdd.Add(resourceStore);
    }
}