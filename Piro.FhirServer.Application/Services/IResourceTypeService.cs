using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Services;

public interface IResourceTypeService
{
    void Add(ResourceType resourceType);
    ResourceType? GetByName(string name);
}