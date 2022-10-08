using Hl7.Fhir.Model;
using System.Collections.Generic;

namespace Piro.FhirServer.Fhir.Stu3.ResourceSupport
{
  public interface IStu3ValidateResourceName
  {
    bool IsKnownResource(string ResourceName); 
  }
}