using Piro.FhirServer.Domain.FhirTools;
using Hl7.Fhir.ElementModel;
using System.Collections.Generic;

namespace Piro.FhirServer.Fhir.Stu3.Indexing
{
  public interface IStu3TypedElementSupport
  {
    IEnumerable<ITypedElement>? Select(IFhirResourceStu3 fhirResource, string Expression);
  }
}