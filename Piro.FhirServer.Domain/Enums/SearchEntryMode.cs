﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Piro.FhirServer.Domain.Enums
{
  public enum SearchEntryMode
  {
    [EnumInfo("Match", "Match")]
    Match = 0,
    [EnumInfo("Include", "Include")]
    Include = 1,
    [EnumInfo("Outcome", "Outcome")]
    Outcome = 2
  }
}
