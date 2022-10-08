﻿using System;
using System.Net;
using Piro.FhirServer.Domain.Enums;

namespace Piro.FhirServer.Domain.Exceptions
{
  public class FhirVersionFatalException : FhirException
  {
    public FhirVersionFatalException(FhirVersion fhirMajorVersion)
    {
      HttpStatusCode = HttpStatusCode.InternalServerError;
      MessageList = new string[] { $"A FhirMajorVersion was not handled by the server. The FhirMajorVersion value literal was: {fhirMajorVersion.GetCode()}" };
    }

    public FhirVersionFatalException(string message)
    {
      HttpStatusCode = HttpStatusCode.InternalServerError;
      MessageList = new string[] { message };
    }
  }
}
