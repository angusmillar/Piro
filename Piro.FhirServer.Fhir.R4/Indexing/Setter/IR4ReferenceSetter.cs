using Piro.FhirServer.Domain.Dto.Indexing;
using Piro.FhirServer.Domain.Enums;
using Hl7.Fhir.ElementModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Piro.FhirServer.Fhir.R4.Indexing.Setter
{ 
  public interface IR4ReferenceSetter
  {
    Task<IList<IndexReference>> SetAsync(ITypedElement typedElement, ResourceType resourceType, int searchParameterId, string searchParameterName);
  }
}