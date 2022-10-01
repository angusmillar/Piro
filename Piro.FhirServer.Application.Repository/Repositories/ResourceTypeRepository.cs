using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Domain.Repositories;

namespace Piro.FhirServer.Application.Repository.Repositories;

public class ResourceTypeRepository :  GenericRepository<ResourceType>, IResourceTypeAdd, IResourceTypeGetByName
{
    public ResourceTypeRepository(AppContext context) : base(context)
    {
    }

    public override void Add(ResourceType entity)
    {
        base.Add(entity);
        Context.SaveChanges();
    }

    public ResourceType? Get(string name)
    {
        return Context.ResourceType.SingleOrDefault(x => x.Name == name);
    }
}