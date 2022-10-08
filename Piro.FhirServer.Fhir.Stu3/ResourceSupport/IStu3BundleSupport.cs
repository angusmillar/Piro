using Piro.FhirServer.Domain.FhirTools;
using Piro.FhirServer.Domain.FhirTools.Bundle;

namespace Piro.FhirServer.Fhir.Stu3.ResourceSupport
{
  public interface IStu3BundleSupport
  {
    FhirResource GetFhirResource(BundleModel bundleModel);
  }
}