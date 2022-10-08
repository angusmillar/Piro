using System;
using System.Collections.Generic;
using System.Text;

namespace Piro.FhirServer.Domain.Enums
{
  public enum SortOrder
  {
    [EnumInfo("asc", "Ascending")]    
    Ascending = 0,
    [EnumInfo("desc", "Descending")]    
    Descending = 1
  }
}
