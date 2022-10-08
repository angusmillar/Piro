using System;
using System.Collections.Generic;
using System.Text;

namespace Piro.FhirServer.Domain.Enums
{
  public enum PreferHandlingType 
  {
    [EnumInfo("strict", "Strict")]
    Strict,
    [EnumInfo("lenient", "Lenient")]
    Lenient 
  };
}
