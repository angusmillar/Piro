using Piro.FhirServer.Domain.Dto.Indexing;
using Piro.FhirServer.Domain.Enums;
using Piro.FhirServer.Domain.StringTools;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;

namespace Piro.FhirServer.Fhir.Stu3.Indexing.Setter
{
  public class Stu3UriSetter : IStu3UriSetter
  {
    private ITypedElement? TypedElement;
    private Piro.FhirServer.Domain.Enums.ResourceType ResourceType;
    private int SearchParameterId;
    private string? SearchParameterName;
    public Stu3UriSetter() { }

    public IList<IndexUri> Set(ITypedElement typedElement, Piro.FhirServer.Domain.Enums.ResourceType resourceType, int searchParameterId, string searchParameterName)
    {
      this.TypedElement = typedElement;
      this.ResourceType = resourceType;
      this.SearchParameterId = searchParameterId;
      this.SearchParameterName = searchParameterName;

      var ResourceIndexList = new List<IndexUri>();

      if (this.TypedElement is IFhirValueProvider FhirValueProvider && FhirValueProvider.FhirValue != null)
      {
        if (FhirValueProvider.FhirValue is FhirUri FhirUri)
        {
          SetUri(FhirUri, ResourceIndexList);
        }
        else if (FhirValueProvider.FhirValue is Oid Oid)
        {
          SetOid(Oid, ResourceIndexList);
        }
        else
        {
          throw new FormatException($"Unknown FhirType: {this.TypedElement.InstanceType} for the SearchParameter entity with the database key of: {this.SearchParameterId.ToString()} for a resource type of: {this.ResourceType.GetCode()} and search parameter name of: {this.SearchParameterName}");
        }
        return ResourceIndexList;
      }
      else
      {
        throw new FormatException($"Unknown FhirType: {this.TypedElement.InstanceType} for the SearchParameter entity with the database key of: {this.SearchParameterId.ToString()} for a resource type of: {this.ResourceType.GetCode()} and search parameter name of: {this.SearchParameterName}");
      }
    }

    private void SetOid(Oid Oid, IList<IndexUri> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Oid.Value))
      {

        ResourceIndexList.Add(new IndexUri(this.SearchParameterId, Oid.Value.Trim()));
      }
    }
    private void SetUri(FhirUri FhirUri, IList<IndexUri> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(FhirUri.Value))
      {
        ResourceIndexList.Add(new IndexUri(this.SearchParameterId, FhirUri.Value.Trim()));
      }
    }

  }
}
