using Piro.FhirServer.Domain.StringTools;
using Piro.FhirServer.Domain.Exceptions;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Piro.FhirServer.Fhir.R4.ResourceSupport
{
  public class ValidateResourceName : IR4ValidateResourceName
  {
    public bool IsKnownResource(string ResourceName)
    {
      return ModelInfo.IsKnownResource(ResourceName);
    }
  }
}
