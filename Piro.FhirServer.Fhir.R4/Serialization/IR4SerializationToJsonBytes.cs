using Hl7.Fhir.Model;
using Piro.FhirServer.Domain.Enums;
using Piro.FhirServer.Domain.FhirTools;

namespace Piro.FhirServer.Fhir.R4.Serialization
{
  public interface IR4SerializationToJsonBytes
  {
    string SerializeToJson(Resource resource, SummaryType summaryType = SummaryType.False);
    byte[] SerializeToJsonBytes(IFhirResourceR4 fhirResource, SummaryType summaryType = SummaryType.False);
    string SerializeToXml(Resource resource, SummaryType summaryType = SummaryType.False);
  }
}