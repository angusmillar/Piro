using Piro.FhirServer.Domain.FhirTools;

namespace Piro.FhirServer.Fhir.R4.ResourceSupport
{
  public interface IR4FhirResourceVersionSupport
  {
    string? GetVersion(IFhirResourceR4 fhirResource);
    void SetVersion(string versionId, IFhirResourceR4 fhirResource);
  }
}