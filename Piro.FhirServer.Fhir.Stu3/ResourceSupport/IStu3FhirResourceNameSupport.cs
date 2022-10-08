using Piro.FhirServer.Domain.FhirTools;

namespace Piro.FhirServer.Fhir.Stu3.ResourceSupport
{
  public interface IStu3FhirResourceNameSupport
  {
    string GetName(IFhirResourceStu3 fhirResource);
  }
}