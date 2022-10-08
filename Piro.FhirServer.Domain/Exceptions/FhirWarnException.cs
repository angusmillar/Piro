using System;
using System.Collections.Generic;
using System.Net;

namespace Piro.FhirServer.Domain.Exceptions
{
  public class FhirWarnException : FhirException
  {
    public FhirWarnException(HttpStatusCode httpStatusCode, string message)
      : base(httpStatusCode, message) { }
    public FhirWarnException(HttpStatusCode httpStatusCode, string message, Exception innerException)
      : base(httpStatusCode, message, innerException) { }
    public FhirWarnException(HttpStatusCode httpStatusCode, string[] messageList)
      : base(httpStatusCode, messageList) { }
    public FhirWarnException(HttpStatusCode httpStatusCode, string[] messageList, Exception innerException)
      : base(httpStatusCode, messageList, innerException) { }
  }
}
