
using Hl7.Fhir.Model;
using Piro.FhirServer.Domain.Enums;


namespace Piro.FhirServer.Domain.FhirTools
{
  public interface IFhirContainedResourceStu3
  {
    string ResourceId { get; }
    FhirVersion FhirVersion { get; }
    ResourceType ResourceType { get; }
    Resource Stu3 { get; set; }
  }
}