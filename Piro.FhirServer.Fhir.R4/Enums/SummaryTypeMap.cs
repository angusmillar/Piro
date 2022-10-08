using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Piro.FhirServer.Domain.Enums;

namespace Piro.FhirServer.Fhir.R4.Enums
{
  public class SummaryTypeMap : MapBase<Piro.FhirServer.Domain.Enums.SummaryType, Hl7.Fhir.Rest.SummaryType>
  {
    private Dictionary<Piro.FhirServer.Domain.Enums.SummaryType, Hl7.Fhir.Rest.SummaryType> _ForwardMap;
    private Dictionary<Hl7.Fhir.Rest.SummaryType, Piro.FhirServer.Domain.Enums.SummaryType> _ReverseMap;
    protected override Dictionary<Piro.FhirServer.Domain.Enums.SummaryType, Hl7.Fhir.Rest.SummaryType> ForwardMap { get { return _ForwardMap; } }
    protected override Dictionary<Hl7.Fhir.Rest.SummaryType, Piro.FhirServer.Domain.Enums.SummaryType> ReverseMap { get { return _ReverseMap; } }
    public SummaryTypeMap()
    {
      _ForwardMap = new Dictionary<Piro.FhirServer.Domain.Enums.SummaryType, Hl7.Fhir.Rest.SummaryType>();
      _ForwardMap.Add(SummaryType.Count, Hl7.Fhir.Rest.SummaryType.Count);
      _ForwardMap.Add(SummaryType.Data, Hl7.Fhir.Rest.SummaryType.Data);
      _ForwardMap.Add(SummaryType.False, Hl7.Fhir.Rest.SummaryType.False);
      _ForwardMap.Add(SummaryType.Text, Hl7.Fhir.Rest.SummaryType.Text);
      _ForwardMap.Add(SummaryType.True, Hl7.Fhir.Rest.SummaryType.True);

      _ReverseMap = _ForwardMap.ToDictionary((i) => i.Value, (i) => i.Key);
    }
  }
}
