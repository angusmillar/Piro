using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Domain.Repositories;

namespace Piro.FhirServer.Application.Repository.Repositories;

public class ResourceTypeRepository :  GenericRepository<ResourceType>, IResourceTypeAdd, IResourceTypeGetByName
{
    public ResourceTypeRepository(AppContext context) : base(context)
    {
    }

    public new async Task Add(ResourceType entity)
    {
        base.Add(entity);
        await Context.SaveChangesAsync();
    }

    public ResourceType? Get(string name)
    {
        return Context.ResourceType.SingleOrDefault(x => x.Name == name);
    }
}