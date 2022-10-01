using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Domain.Repositories;

namespace Piro.FhirServer.Application.Services;

public class ResourceStoreService : IResourceStoreService
{
    private readonly IResourceStoreAdd _resourceStoreAdd;
    private readonly IResourceStoreSearch _resourceStoreSearch;
    

    public ResourceStoreService(IResourceStoreAdd resourceStoreAdd, IResourceStoreSearch resourceStoreSearch)
    {
        _resourceStoreAdd = resourceStoreAdd;
        _resourceStoreSearch = resourceStoreSearch;
    }

    public async Task Add(ResourceStore resourceStore)
    {
        await _resourceStoreAdd.Add(resourceStore);
    }
    
    public IEnumerable<ResourceStore>  Search()
    {
        return _resourceStoreSearch.Search();
    }
}