using System;
using System.Collections.Generic;
using System.Text;

namespace Piro.FhirServer.Domain.Enums
{
  public enum QuantityComparator
  {
    [EnumInfo("<", "LessThan")]
    LessThan = 0,
    [EnumInfo("<=", "LessOrEqual")]
    LessOrEqual = 1,
    [EnumInfo(">=", "GreaterOrEqual")]
    GreaterOrEqual = 2,
    [EnumInfo(">", "GreaterThan")]
    GreaterThan = 3
  }
}
