using System;

namespace Piro.FhirServer.Domain.ApplicationConfig
{
  public interface IServerDefaultTimeZoneTimeSpan
  {
    TimeSpan ServerDefaultTimeZoneTimeSpan { get; set; }
  }
}