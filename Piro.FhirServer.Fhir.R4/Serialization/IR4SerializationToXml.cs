using Hl7.Fhir.Model;

namespace Piro.FhirServer.Fhir.R4.Serialization
{
  public interface IR4SerializationToXml
  {
    string SerializeToXml(Resource resource,  Piro.FhirServer.Domain.Enums.SummaryType summaryType =  Piro.FhirServer.Domain.Enums.SummaryType.False);
  }
}