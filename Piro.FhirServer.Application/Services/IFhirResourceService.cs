using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Services;

public interface IFhirResourceService
{
    void Add(FhirResource fhirResource);
}