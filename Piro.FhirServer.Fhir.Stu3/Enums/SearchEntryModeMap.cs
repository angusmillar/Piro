using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Piro.FhirServer.Domain.Enums;

namespace Piro.FhirServer.Fhir.Stu3.Enums
{
  public class SearchEntryModeMap : MapBase<SearchEntryMode, Hl7.Fhir.Model.Bundle.SearchEntryMode>
  {    
    private Dictionary<SearchEntryMode, Hl7.Fhir.Model.Bundle.SearchEntryMode> _ForwardMap;
    private Dictionary<Hl7.Fhir.Model.Bundle.SearchEntryMode, SearchEntryMode> _ReverseMap;

    protected override Dictionary<SearchEntryMode, Hl7.Fhir.Model.Bundle.SearchEntryMode> ForwardMap { get { return _ForwardMap; } }
    protected override Dictionary<Hl7.Fhir.Model.Bundle.SearchEntryMode, SearchEntryMode> ReverseMap { get { return _ReverseMap; } }
    public SearchEntryModeMap()
    {
      _ForwardMap = new Dictionary<SearchEntryMode, Hl7.Fhir.Model.Bundle.SearchEntryMode>();
      _ForwardMap.Add(SearchEntryMode.Include, Hl7.Fhir.Model.Bundle.SearchEntryMode.Include);
      _ForwardMap.Add(SearchEntryMode.Match, Hl7.Fhir.Model.Bundle.SearchEntryMode.Match);
      _ForwardMap.Add(SearchEntryMode.Outcome, Hl7.Fhir.Model.Bundle.SearchEntryMode.Outcome);

      _ReverseMap = _ForwardMap.ToDictionary((i) => i.Value, (i) => i.Key);
    }    
  }
}
