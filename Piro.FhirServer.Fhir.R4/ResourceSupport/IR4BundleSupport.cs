using Piro.FhirServer.Domain.FhirTools;
using Piro.FhirServer.Domain.FhirTools.Bundle;

namespace Piro.FhirServer.Fhir.R4.ResourceSupport
{
  public interface IR4BundleSupport
  {
    FhirResource GetFhirResource(BundleModel bundleModel);
  }
}