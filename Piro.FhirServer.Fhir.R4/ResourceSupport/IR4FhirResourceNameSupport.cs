using Piro.FhirServer.Domain.FhirTools;

namespace Piro.FhirServer.Fhir.R4.ResourceSupport
{
  public interface IR4FhirResourceNameSupport
  {
    string GetName(IFhirResourceR4 fhirResource);    
  }
}