using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Repository.Repositories;

public class ResourceTypeRepository :  GenericRepository<ResourceType>, IResourceTypeRepository
{
    public ResourceTypeRepository(AppContext context) : base(context)
    {
    }
    
    public ResourceType? GetByName(string name)
    {
        return Context.ResourceType.SingleOrDefault(x => x.Name == name);
    }
    
}