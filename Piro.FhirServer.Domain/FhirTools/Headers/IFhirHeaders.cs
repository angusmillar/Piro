using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using Piro.FhirServer.Domain.Enums;

namespace Piro.FhirServer.Domain.FhirTools.Headers
{
  public interface IFhirHeaders
  {
    Dictionary<string, StringValues> HeaderDictionary { get; }
    PreferHandlingType PreferHandling { get; }    
  }
}