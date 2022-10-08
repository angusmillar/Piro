using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Piro.FhirServer;
using Piro.FhirServer.Domain.Enums;

namespace Piro.FhirServer.Fhir.Stu3.Enums
{
  public class SummaryTypeMap : MapBase<Domain.Enums.SummaryType, Hl7.Fhir.Rest.SummaryType>
  {
    private Dictionary<Domain.Enums.SummaryType, Hl7.Fhir.Rest.SummaryType> _ForwardMap;
    private Dictionary<Hl7.Fhir.Rest.SummaryType, Domain.Enums.SummaryType> _ReverseMap;
    protected override Dictionary<Domain.Enums.SummaryType, Hl7.Fhir.Rest.SummaryType> ForwardMap { get { return _ForwardMap; } }
    protected override Dictionary<Hl7.Fhir.Rest.SummaryType, Domain.Enums.SummaryType> ReverseMap { get { return _ReverseMap; } }
    public SummaryTypeMap()
    {
      _ForwardMap = new Dictionary<Domain.Enums.SummaryType, Hl7.Fhir.Rest.SummaryType>();
      _ForwardMap.Add(Domain.Enums.SummaryType.Count, Hl7.Fhir.Rest.SummaryType.Count);
      _ForwardMap.Add(Domain.Enums.SummaryType.Data, Hl7.Fhir.Rest.SummaryType.Data);
      _ForwardMap.Add(Domain.Enums.SummaryType.False, Hl7.Fhir.Rest.SummaryType.False);
      _ForwardMap.Add(Domain.Enums.SummaryType.Text, Hl7.Fhir.Rest.SummaryType.Text);
      _ForwardMap.Add(Domain.Enums.SummaryType.True, Hl7.Fhir.Rest.SummaryType.True);

      _ReverseMap = _ForwardMap.ToDictionary((i) => i.Value, (i) => i.Key);
    }    
  }
}
