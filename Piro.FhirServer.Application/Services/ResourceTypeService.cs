using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Domain.Repositories;

namespace Piro.FhirServer.Application.Services;

public class ResourceTypeService : IResourceTypeService
{
    private readonly IResourceTypeAdd _resourceTypeAdd;
    private readonly IResourceTypeGetByName _resourceTypeGetByName;

    public ResourceTypeService(IResourceTypeAdd resourceTypeAdd, IResourceTypeGetByName resourceTypeGetByName)
    {
        _resourceTypeAdd = resourceTypeAdd;
        _resourceTypeGetByName = resourceTypeGetByName;
    }

    public void Add(ResourceType resourceType)
    {
        _resourceTypeAdd.Add(resourceType);
    }

    public ResourceType? GetByName(string name)
    {
        return _resourceTypeGetByName.Get(name);
    }
}

