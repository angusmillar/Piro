using System;
using System.Collections.Generic;
using System.Text;
using Piro.FhirServer.Domain.Enums;
using SearchComparator = Piro.FhirServer.Domain.Enums.SearchComparator;
using SearchModifierCode = Piro.FhirServer.Domain.Enums.SearchModifierCode;

namespace Piro.FhirServer.Domain.FhirTools.SearchQuery
{
  public static class SearchQuerySupport
  {
    public static Enums.SearchComparator[] GetPrefixListForSearchType(Enums.SearchParamType SearchParamType)
    {
      return SearchParamType switch
      {
        Enums.SearchParamType.Number => new Enums.SearchComparator[] {
            Enums.SearchComparator.Ne,
            Enums.SearchComparator.Eq,
            Enums.SearchComparator.Gt,
            Enums.SearchComparator.Ge,
            Enums.SearchComparator.Lt,
            Enums.SearchComparator.Le
          },
        Enums.SearchParamType.Date => new Enums.SearchComparator[] {
            Enums.SearchComparator.Ne,
            Enums.SearchComparator.Eq,
            Enums.SearchComparator.Gt,
            Enums.SearchComparator.Ge,
            Enums.SearchComparator.Lt,
            Enums.SearchComparator.Le
          },
        Enums.SearchParamType.String => new Enums.SearchComparator[] { },//Any search parameter that's value is a string will not have prefixes
        Enums.SearchParamType.Token => new Enums.SearchComparator[] { },//Any search parameter that's value is a string will not have prefixes
        Enums.SearchParamType.Reference => new Enums.SearchComparator[] { },//Any search parameter that's value is a string will not have prefixes
        Enums.SearchParamType.Composite => new Enums.SearchComparator[] { },//Any search parameter that's value is a string will not have prefixes
        Enums.SearchParamType.Quantity => new Enums.SearchComparator[] {
            Enums.SearchComparator.Ne,
            Enums.SearchComparator.Eq,
            Enums.SearchComparator.Gt,
            Enums.SearchComparator.Ge,
            Enums.SearchComparator.Lt,
            Enums.SearchComparator.Le
          },
        Enums.SearchParamType.Uri => new Enums.SearchComparator[] { },//Any search parameter that's value is a string will not have prefixes
        Enums.SearchParamType.Special => new Enums.SearchComparator[] { },
        _ => throw new System.ComponentModel.InvalidEnumArgumentException(SearchParamType.GetCode(), (int)SearchParamType, typeof(Enums.SearchParamType)),
      };
    }

    public static Enums.SearchModifierCode[] GetModifiersForSearchType(Enums.SearchParamType SearchParamType)
    {
      return SearchParamType switch
      {
        Enums.SearchParamType.Number => new Enums.SearchModifierCode[] { Enums.SearchModifierCode.Missing },
        Enums.SearchParamType.Date => new Enums.SearchModifierCode[] { Enums.SearchModifierCode.Missing },
        Enums.SearchParamType.String => new Enums.SearchModifierCode[]
        {
            Enums.SearchModifierCode.Missing,
            Enums.SearchModifierCode.Contains,
            Enums.SearchModifierCode.Exact
        },
        Enums.SearchParamType.Token => new Enums.SearchModifierCode[] { Enums.SearchModifierCode.Missing },
        //The modifiers below are supported in the spec for token but not 
        //implemented by this server as yet
        //ReturnList.Add(Conformance.SearchModifierCode.Text.ToString());
        //ReturnList.Add(Conformance.SearchModifierCode.In.ToString());
        //ReturnList.Add(Conformance.SearchModifierCode.Below.ToString());
        //ReturnList.Add(Conformance.SearchModifierCode.Above.ToString());
        //ReturnList.Add(Conformance.SearchModifierCode.In.ToString());
        //ReturnList.Add(Conformance.SearchModifierCode.NotIn.ToString());          
        Enums.SearchParamType.Reference => new Enums.SearchModifierCode[]
        {
            Enums.SearchModifierCode.Missing,
            Enums.SearchModifierCode.Type,
        },
        Enums.SearchParamType.Composite => new Enums.SearchModifierCode[] { },
        Enums.SearchParamType.Quantity => new Enums.SearchModifierCode[] { Enums.SearchModifierCode.Missing },
        Enums.SearchParamType.Uri => new Enums.SearchModifierCode[]
        {
            Enums.SearchModifierCode.Missing,
            Enums.SearchModifierCode.Below,
            Enums.SearchModifierCode.Above,
            Enums.SearchModifierCode.Contains,
            Enums.SearchModifierCode.Exact
        },
        SearchParamType.Special => new Enums.SearchModifierCode[] { SearchModifierCode.Missing },
        _ => throw new System.ComponentModel.InvalidEnumArgumentException(SearchParamType.ToString(), (int)SearchParamType, typeof(SearchParamType)),
      };
    }
  }
}
