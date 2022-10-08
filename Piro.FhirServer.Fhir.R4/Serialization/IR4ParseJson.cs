using Hl7.Fhir.Model;

namespace Piro.FhirServer.Fhir.R4.Serialization
{
  public interface IR4ParseJson
  {
    Resource ParseJson(string jsonResource);
  }
}