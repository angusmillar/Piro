using Piro.FhirServer.Domain.FhirTools;
using System.Collections.Generic;

namespace Piro.FhirServer.Fhir.Stu3.ResourceSupport
{
  public interface IStu3ContainedResourceDictionary
  {
    public IList<FhirContainedResource> GetContainedResourceDictionary(IFhirResourceStu3 fhirResource);
  }
}