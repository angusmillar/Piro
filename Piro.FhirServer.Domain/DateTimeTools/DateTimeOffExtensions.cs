using System;
using System.Collections.Generic;
using System.Text;

namespace Piro.FhirServer.Domain.DateTimeTools
{
  public static class DateTimeOffExtensions
  {
    public static DateTime ToZulu(this DateTimeOffset dateTimeOffset)
    {
      return dateTimeOffset.UtcDateTime;
    }

  }
}
