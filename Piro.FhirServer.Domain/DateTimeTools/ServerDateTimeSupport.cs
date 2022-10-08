using System;
using System.Collections.Generic;
using System.Text;
using Piro.FhirServer.Domain.ApplicationConfig;

namespace Piro.FhirServer.Domain.DateTimeTools
{
  public class ServerDateTimeSupport : IServerDateTimeSupport
  {
    private readonly IServerDefaultTimeZoneTimeSpan IServerDefaultTimeZoneTimeSpan;
    
    public ServerDateTimeSupport(IServerDefaultTimeZoneTimeSpan IServerDefaultTimeZoneTimeSpan, IFhirServerConfig IFhirServerConfig)
    {
      this.IServerDefaultTimeZoneTimeSpan = IServerDefaultTimeZoneTimeSpan;      
    }

    public DateTimeOffset Now()
    {      
      return DateTimeOffset.Now.ToOffset(IServerDefaultTimeZoneTimeSpan.ServerDefaultTimeZoneTimeSpan);
    }

    public DateTimeOffset ZuluToServerTimeZone(DateTime zuluDateTime)
    {
      return new DateTimeOffset(zuluDateTime).ToOffset(IServerDefaultTimeZoneTimeSpan.ServerDefaultTimeZoneTimeSpan);
    }
  }
}
