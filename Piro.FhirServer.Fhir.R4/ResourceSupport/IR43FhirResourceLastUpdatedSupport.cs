using Piro.FhirServer.Domain.FhirTools;
using System;

namespace Piro.FhirServer.Fhir.R4.ResourceSupport
{
  public interface IR4FhirResourceLastUpdatedSupport
  {
    DateTimeOffset? GetLastUpdated(IFhirResourceR4 fhirResource);
    void SetLastUpdated(DateTimeOffset dateTimeOffset, IFhirResourceR4 fhirResource);
  }
}