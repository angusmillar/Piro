using System;
using Piro.FhirServer.Domain.Enums;

namespace Piro.FhirServer.Domain.ApplicationConfig
{
  public interface IFhirServerConfig
  {
    FhirFormatType DefaultFhirFormat { get; set; }
    Uri ServiceBaseUrl { get; set; }
    int CahceSlidingExpirationMinites { get; set; }

    TimeSpan ServerDefaultTimeZoneTimeSpan { get; set; }
  }
}