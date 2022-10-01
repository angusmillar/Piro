using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Services;

public interface IResourceStoreService
{
    void Add(ResourceStore resourceStore);
}