using Piro.FhirServer.Domain.FhirTools;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;

namespace Piro.FhirServer.Fhir.Stu3.ResourceSupport
{
  public interface IStu3FhirResourceLastUpdatedSupport
  {
    void SetLastUpdated(DateTimeOffset dateTimeOffset, IFhirResourceStu3 fhirResource);    
    DateTimeOffset? GetLastUpdated(IFhirResourceStu3 fhirResource);
  }
}