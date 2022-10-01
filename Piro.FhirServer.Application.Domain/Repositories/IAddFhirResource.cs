using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Domain.Repositories;

public interface IAddFhirResource
{
    public void Add(FhirResource fhirResource);
}