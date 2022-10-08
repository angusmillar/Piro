using Hl7.Fhir.Model;
using System.Collections.Generic;

namespace Piro.FhirServer.Fhir.R4.ResourceSupport
{
  public interface IR4ValidateResourceName
  {
    bool IsKnownResource(string ResourceName);    
  }
}