using Piro.FhirServer.Domain.FhirTools;
using System.Collections.Generic;

namespace Piro.FhirServer.Fhir.R4.ResourceSupport
{
  public interface IR4ContainedResourceDictionary
  {
    IList<FhirContainedResource> GetContainedResourceDictionary(IFhirResourceR4 fhirResource);
  }
}