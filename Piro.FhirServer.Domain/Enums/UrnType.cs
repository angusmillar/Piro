using System;
using System.Collections.Generic;
using System.Text;

namespace Piro.FhirServer.Domain.Enums
{
  public enum UrnType
  {
    [EnumInfo("uuid", "uuid")]
    uuid,
    [EnumInfo("oid", "oid")]
    oid
  }
}
