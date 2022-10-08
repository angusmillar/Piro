using System;
using Piro.FhirServer.Domain.Enums;

namespace Piro.FhirServer.Domain.ApplicationConfig
{
  public interface IServiceBaseUrlConfi
  {
    Uri Url(FhirVersion fhirMajorVersion);
  }
}