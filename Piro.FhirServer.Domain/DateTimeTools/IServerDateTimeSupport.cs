using System;

namespace Piro.FhirServer.Domain.DateTimeTools
{
  public interface IServerDateTimeSupport
  {
    DateTimeOffset Now();
    DateTimeOffset ZuluToServerTimeZone(DateTime zuluDateTime);
  }
}