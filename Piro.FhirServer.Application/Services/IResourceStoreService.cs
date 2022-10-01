using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Services;

public interface IResourceStoreService
{
    Task Add(ResourceStore resourceStore);
    
    
}