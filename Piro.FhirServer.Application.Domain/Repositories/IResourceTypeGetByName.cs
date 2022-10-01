using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Domain.Repositories;

public interface IResourceTypeGetByName
{
    public ResourceType? Get(string name);
}