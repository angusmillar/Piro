using Piro.FhirServer.Domain.FhirTools;
using Hl7.Fhir.ElementModel;
using System.Collections.Generic;

namespace Piro.FhirServer.Fhir.R4.Indexing
{
  public interface IR4TypedElementSupport
  {    
    IEnumerable<ITypedElement>? Select(IFhirResourceR4 fhirResource, string Expression);
  }
}