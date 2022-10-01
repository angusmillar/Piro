using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Domain.Repositories;

public interface IGetResourceByFhirId
{
    public FhirResource? Get(string fhirId);
}