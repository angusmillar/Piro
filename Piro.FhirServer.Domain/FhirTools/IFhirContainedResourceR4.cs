
using Hl7.Fhir.Model;
using Piro.FhirServer.Domain.Enums;

namespace Piro.FhirServer.Domain.FhirTools
{
  public interface IFhirContainedResourceR4
  {
    string ResourceId { get;  }
    FhirVersion FhirVersion { get; }
    Resource R4 { get; set; }
    ResourceType ResourceType { get; }
  }
}