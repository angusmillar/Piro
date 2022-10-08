extern alias R4;
extern alias Stu3;
using R4Rest = R4.Hl7.Fhir.Rest;
using R4Model = R4.Hl7.Fhir.Model;
using R4Serialization = R4.Hl7.Fhir.Serialization;
using Stu3Rest = Stu3.Hl7.Fhir.Rest;
using Stu3Model = Stu3.Hl7.Fhir.Model;
using Stu3Serialization = Stu3.Hl7.Fhir.Serialization;
using Hl7.Fhir.Utility;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Piro.FhirServer.Domain.Enums;
using Piro.FhirServer.Domain.Exceptions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Piro.FhirServer.Api.ContentFormatters
{
  public class JsonFhirOutputFormatter : FhirMediaTypeOutputFormatter
  {
    public JsonFhirOutputFormatter()
    {
      foreach (var mediaType in Hl7.Fhir.Rest.ContentType.JSON_CONTENT_HEADERS)
        SupportedMediaTypes.Add(new MediaTypeHeaderValue(mediaType));
    }

    public override void WriteResponseHeaders(OutputFormatterWriteContext context)
    {
      if (context is null)
        throw new ArgumentNullException(nameof(context));

      if (context.ObjectType is not null)
      {
        context.ContentType = FhirMediaType.GetMediaTypeHeaderValue(context.ObjectType, FhirFormatType.json);  
      }
      
      // note that the base is called last, as this may overwrite the ContentType where the resource is of type Binary
      base.WriteResponseHeaders(context);
    }

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
      if (context == null)
        throw new ArgumentNullException(nameof(context));

      if (context.Object is Resource resource)
      {
        FhirVersion? fhirVersion = GetFhirVersion(resource);
        SummaryType? summaryType = GetFhirSummaryType(resource);
        SerializationFilter? serializationFilter = GetSerializationFilter(summaryType);

        var options = GetJsonSerializerOptions(fhirVersion, serializationFilter);
        
        //For debugging:
        //string Json = JsonSerializer.Serialize(context.Object, options);
        
        await context.HttpContext.Response.WriteAsync(JsonSerializer.Serialize(context.Object, options));
      }
    }

    private static FhirVersion? GetFhirVersion(Resource resource)
    {
      if (resource.HasAnnotation<FhirVersion>())
      {
        return resource.Annotation<FhirVersion>();
      }
      return null;
    }

    private static SummaryType? GetFhirSummaryType(Resource resource)
    {
      if (resource.HasAnnotation<SummaryType>())
      {
        return resource.Annotation<SummaryType>();
      }
      return null;
    }

    private static SerializationFilter? GetSerializationFilter(SummaryType? summaryType)
    {
      return summaryType switch
      {
        SummaryType.True => SerializationFilter.ForSummary(),
        SummaryType.Text => SerializationFilter.ForText(),
        SummaryType.Data => SerializationFilter.ForData(),
        SummaryType.Count => null,
        SummaryType.False => null,
        null => null,
        _ => throw new FhirFatalException(System.Net.HttpStatusCode.BadRequest,
          $"Unable to resolve SummaryType for value: {summaryType}.")
      };
    }

    private static JsonSerializerOptions GetJsonSerializerOptions(FhirVersion? fhirVersion,
      SerializationFilter? serializationFilter)
    {
      var settings = new FhirJsonPocoSerializerSettings()
      {
        SummaryFilter = serializationFilter
      };
      
      JsonSerializerOptions options;
      switch (fhirVersion)
      {
        case FhirVersion.Stu3:
          options = new JsonSerializerOptions().ForFhir(typeof(Stu3.Hl7.Fhir.Model.Bundle).Assembly, settings)
            .Pretty();
          break;
        case FhirVersion.R4:
          options = new JsonSerializerOptions().ForFhir(typeof(R4.Hl7.Fhir.Model.Bundle).Assembly, settings)
            .Pretty();
          break;
        default:
          throw new FhirFatalException(System.Net.HttpStatusCode.BadRequest, $"Unable to resolve which version of FHIR is in use, {fhirVersion} was null.");
      }
      return options;
    }
  }
}