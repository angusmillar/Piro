using Piro.FhirServer.Domain.Dto.Indexing;
using Piro.FhirServer.Domain.Enums;
using Hl7.Fhir.ElementModel;
using System.Collections.Generic;

namespace Piro.FhirServer.Fhir.Stu3.Indexing.Setter
{
  public interface IStu3QuantitySetter
  {
    IList<IndexQuantity> Set(ITypedElement typedElement, ResourceType resourceType, int searchParameterId, string searchParameterName);
  }
}