using Hl7.Fhir.Model;

namespace Piro.FhirServer.Fhir.Stu3.Serialization
{
  public interface IStu3ParseJson
  {
    Resource ParseJson(string jsonResource);
  }
}