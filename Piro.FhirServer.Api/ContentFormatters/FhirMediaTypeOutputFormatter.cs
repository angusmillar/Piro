extern alias R4;
extern alias Stu3;
using R4Model = R4.Hl7.Fhir.Model;
using Stu3Model = Stu3.Hl7.Fhir.Model;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Text;

namespace Piro.FhirServer.Api.ContentFormatters
{
  public abstract class FhirMediaTypeOutputFormatter : TextOutputFormatter
  {
    protected FhirMediaTypeOutputFormatter()
    {
      this.SupportedEncodings.Clear();
      this.SupportedEncodings.Add(Encoding.UTF8);
    }

    protected override bool CanWriteType(Type? type)
    {
      if (typeof(Hl7.Fhir.Model.Resource).IsAssignableFrom(type))
        return true;
      
      // The null case here is to support the deleted FhirObjectResult
      if (type is null)
        return true;
      
      return false;
    }

    public override void WriteResponseHeaders(OutputFormatterWriteContext context)
    {
      if (context is null)
        throw new ArgumentNullException(nameof(context));

      base.WriteResponseHeaders(context);
      WriteFhirBinaryResourceContentType(context);
    }

    private static void WriteFhirBinaryResourceContentType(OutputFormatterWriteContext context)
    {
      if (context.Object is R4Model.Binary)
      {
        context.HttpContext.Response.Headers.Add(HeaderNames.ContentType, ((R4Model.Binary)context.Object).ContentType);
        context.ContentType =
          new Microsoft.Extensions.Primitives.StringSegment(((R4Model.Binary)context.Object).ContentType);
      }

      if (context.Object is Stu3Model.Binary)
      {
        context.HttpContext.Response.Headers.Add(HeaderNames.ContentType, ((Stu3Model.Binary)context.Object).ContentType);
        context.ContentType =
          new Microsoft.Extensions.Primitives.StringSegment(((Stu3Model.Binary)context.Object).ContentType);
      }
    }
  }
}
