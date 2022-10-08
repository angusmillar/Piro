using System;
using System.Collections.Generic;
using System.Net;

namespace Piro.FhirServer.Domain.Exceptions
{
  public class FhirErrorException : FhirException
  {
    public FhirErrorException(HttpStatusCode httpStatusCode, string message)
      : base(httpStatusCode, message) { }
    public FhirErrorException(HttpStatusCode httpStatusCode, string message, Exception innerException)
      : base(httpStatusCode, message, innerException) { }
    public FhirErrorException(HttpStatusCode httpStatusCode, string[] messageList)
      : base(httpStatusCode, messageList) { }
    public FhirErrorException(HttpStatusCode httpStatusCode, string[] messageList, Exception innerException)
      : base(httpStatusCode, messageList, innerException) { }
  }
}
