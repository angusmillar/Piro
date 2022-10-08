using System;
using System.Collections.Generic;
using System.Text;

namespace Piro.FhirServer.Domain.Enums
{
  public enum ContainedType
  {
    [EnumInfo("container", "Container")]
    Container = 0,
    [EnumInfo("contained", "Contained")]
    Contained = 1,   
  }
}
