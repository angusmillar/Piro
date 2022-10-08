﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Piro.FhirServer.Domain.FhirTools
{
  public static class FhirGuidSupport
  {
    /// <summary>
    /// CReate a new random FHIR guid
    /// </summary>
    /// <returns></returns>
    public static string NewFhirGuid()
    {
      return System.Guid.NewGuid().ToString("D");
    }

    /// <summary>
    /// Test that this is a FHIR guid, returns true if it is
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    public static bool IsFhirGuid(string guid)
    {
      Guid TempGuid;
      return (Guid.TryParseExact(guid, "D", out TempGuid));
    }
  }
}
