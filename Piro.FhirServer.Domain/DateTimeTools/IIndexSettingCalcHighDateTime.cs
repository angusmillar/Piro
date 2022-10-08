using System;
using Piro.FhirServer.Domain.Enums;

namespace Piro.FhirServer.Domain.DateTimeTools
{
  public interface IIndexSettingCalcHighDateTime
  {
    DateTime IndexSettingCalculateHighDateTimeForRange(DateTime LowValue, DateTimePrecision Precision);
  }
}