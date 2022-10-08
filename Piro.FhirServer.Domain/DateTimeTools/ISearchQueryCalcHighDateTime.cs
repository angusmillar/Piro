using System;
using Piro.FhirServer.Domain.Enums;

namespace Piro.FhirServer.Domain.DateTimeTools
{
  public interface ISearchQueryCalcHighDateTime
  {
    DateTime SearchQueryCalculateHighDateTimeForRange(DateTime LowValue, DateTimePrecision Precision);
  }
}