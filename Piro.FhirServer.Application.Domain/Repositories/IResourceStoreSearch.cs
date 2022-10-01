using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Domain.Repositories;

public interface IResourceStoreSearch
{ 
    IEnumerable<ResourceStore> Search();
}