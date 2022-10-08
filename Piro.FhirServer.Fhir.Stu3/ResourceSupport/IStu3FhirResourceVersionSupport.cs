using Piro.FhirServer.Domain.FhirTools;

namespace Piro.FhirServer.Fhir.Stu3.ResourceSupport
{
  public interface IStu3FhirResourceVersionSupport
  {
    string? GetVersion(IFhirResourceStu3 fhirResource);
    void SetVersion(string versionId, IFhirResourceStu3 fhirResource);
  }
}