using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Repository.Repositories;

public interface IResourceTypeRepository: IGenericRepository<ResourceType>
{
    ResourceType? GetByName(string name);
}