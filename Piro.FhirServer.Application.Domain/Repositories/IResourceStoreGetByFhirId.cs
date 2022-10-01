using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Domain.Repositories;

public interface IResourceStoreGetByFhirId
{
    public ResourceStore? Get(string fhirId);
}