using Piro.FhirServer.Domain.Enums;

namespace Piro.FhirServer.Domain.Interfaces
{
  public interface IFhirUriFactory
  {
    bool TryParse(string requestUri, FhirVersion fhirMajorVersion, out IFhirUri? fhirUri, out string errorMessage);
  }
}