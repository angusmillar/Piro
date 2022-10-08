using System;
using System.Collections.Generic;
using System.Text;
using Piro.FhirServer.Domain.Enums;

namespace Piro.FhirServer.Domain.DateTimeTools
{
  public class FhirDateTime
  {
    public FhirDateTime(DateTime DateTime, DateTimePrecision Precision)
    {
      this.DateTime = DateTime;
      this.Precision = Precision;
    }

    public DateTime DateTime { get; set; }
    public DateTimePrecision Precision { get; set; }
  }
}
