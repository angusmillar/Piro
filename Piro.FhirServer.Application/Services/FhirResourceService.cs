using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Domain.Repositories;

namespace Piro.FhirServer.Application.Services;

public class FhirResourceService : IFhirResourceService
{
    private readonly IAddFhirResource _addFhirResource;

    public FhirResourceService(IAddFhirResource addFhirResource)
    {
        _addFhirResource = addFhirResource;
    }

    public void Add(FhirResource fhirResource)
    {
        _addFhirResource.Add(fhirResource);
    }
}