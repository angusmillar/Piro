using Piro.FhirServer.Domain.FhirTools;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;

namespace Piro.FhirServer.Fhir.Stu3.ResourceSupport
{
  public interface IStu3FhirResourceIdSupport
  {
    string? GetFhirId(IFhirResourceStu3 fhirResource);
    void SetFhirId(string id, IFhirResourceStu3 fhirResource);

  }
}