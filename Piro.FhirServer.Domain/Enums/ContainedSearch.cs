using System;
using System.Collections.Generic;
using System.Text;

namespace Piro.FhirServer.Domain.Enums
{
  public enum ContainedSearch
  {
    [EnumInfo("true", "True")]
    True = 0,
    [EnumInfo("false", "False")]
    False = 1,
    [EnumInfo("both", "Both")]
    Both = 2
  }
}
