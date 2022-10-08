using System;
using System.Collections.Generic;
using System.Text;

namespace Piro.FhirServer.Domain.Enums
{
  public enum OperationScope
  {
    [EnumInfo("Base", "Base")]
    Base,
    [EnumInfo("Resource", "Resource")]
    Resource,
    [EnumInfo("Instance", "Instance")]
    Instance
  }
}
