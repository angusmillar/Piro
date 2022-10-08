using Piro.FhirServer.Domain.FhirTools;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace Piro.FhirServer.Fhir.Stu3.Serialization
{
  public interface IStu3SerializationToJsonBytes
  {
    byte[] SerializeToJsonBytes(IFhirResourceStu3 fhirResource, Piro.FhirServer.Domain.Enums.SummaryType summaryType = Piro.FhirServer.Domain.Enums.SummaryType.False);
  }
}