using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Domain.Repositories;

public interface IResourceStoreAdd
{
    public void Add(ResourceStore resourceStore);
}