using Piro.FhirServer.Domain.FhirTools;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;

namespace Piro.FhirServer.Fhir.R4.ResourceSupport
{
  public interface IR4FhirResourceIdSupport
  {
    string? GetFhirId(IFhirResourceR4 fhirResource);
    string SetFhirId(string id, IFhirResourceR4 fhirResource);

  }
}