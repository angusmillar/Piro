using Piro.FhirServer.Domain.Enums;

namespace Piro.FhirServer.Domain.FhirTools
{
  public interface IResourceTypeSupport
  {
    ResourceType? GetTypeFromName(string name);
  }
}