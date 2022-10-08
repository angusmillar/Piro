namespace Piro.FhirServer.Fhir.Stu3.ResourceSupport
{
  public interface IStu3IsKnownResource
  {
    bool IsKnownResource(string resourceName);
  }
}