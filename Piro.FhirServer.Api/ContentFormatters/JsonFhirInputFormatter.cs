extern alias Stu3;
extern alias R4;
using R4Serialization = R4.Hl7.Fhir.Serialization;
using Stu3Serialization = R4.Hl7.Fhir.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Hl7.Fhir.Serialization;
using Piro.FhirServer.Domain.Enums;
using Piro.FhirServer.Domain.Exceptions;

namespace Piro.FhirServer.Api.ContentFormatters
{
  public class JsonFhirInputFormatter : FhirMediaTypeInputFormatter
  {
    public JsonFhirInputFormatter() 
    {
      foreach (var mediaType in Hl7.Fhir.Rest.ContentType.JSON_CONTENT_HEADERS)
        SupportedMediaTypes.Add(new MediaTypeHeaderValue(mediaType));
    }

    public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
    {
      CheckForUtf8Encoding(encoding);
      await DrainRequestBodyStream(context.HttpContext.Request);
      SetMajorFhirVersion(context.HttpContext.Request.RouteValues);
      var resource = await DeserializeFhirResource(context.HttpContext.Request, GetJsonSerializerOptions());
      return await InputFormatterResult.SuccessAsync(resource);
    }

    private static void CheckForUtf8Encoding(Encoding encoding)
    {
      if (encoding.EncodingName != Encoding.UTF8.EncodingName)
      {
        throw new FhirFatalException(System.Net.HttpStatusCode.BadRequest,
          "FHIR supports UTF-8 encoding exclusively. The encoding found was : " + encoding.WebName);
      }
    }

    private static async Task DrainRequestBodyStream(HttpRequest request)
    {
      // TODO: Brian: Would like to know what the issue is here? Will this be resolved by the Async update to the core?
      if (!request.Body.CanSeek)
      {
        // To avoid blocking on the stream, we asynchronously read everything 
        // into a buffer, and then seek back to the beginning.
        request.EnableBuffering();
        Debug.Assert(request.Body.CanSeek);

        // no timeout configuration on this? or does that happen at another layer?
        await request.Body.DrainAsync(CancellationToken.None);
        request.Body.Seek(0L, SeekOrigin.Begin);
      }
    }

    private JsonSerializerOptions GetJsonSerializerOptions()
    {
      JsonSerializerOptions? jsonSerializerOptions;
      FhirJsonPocoDeserializerSettings settings = new FhirJsonPocoDeserializerSettings()
      {
        DisableBase64Decoding = false,
        Validator = null,
      };
      
      switch (FhirMajorVersion)
      {
        case FhirVersion.Stu3:
          jsonSerializerOptions = new JsonSerializerOptions().ForFhir(typeof(Stu3.Hl7.Fhir.Model.Patient).Assembly, settings);
          break;
        case FhirVersion.R4:
          jsonSerializerOptions = new JsonSerializerOptions().ForFhir(typeof(R4.Hl7.Fhir.Model.Patient).Assembly, settings);
          break;
        case null:
          throw new FhirFatalException(System.Net.HttpStatusCode.BadRequest, $"Unable to resolve which major version of FHIR is in use, {FhirMajorVersion} was null.");
        default:
          throw new FhirFatalException(System.Net.HttpStatusCode.BadRequest, "Unable to resolve which major version of FHIR is in use.");
      }
      
      // need to configure these properties as is done in 
      // HL7.Fhir.SerializationUtil.JsonReaderFromJsonText()
      //jsonReader.DateParseHandling = DateParseHandling.None;
      //jsonReader.FloatParseHandling = FloatParseHandling.Decimal;
      return jsonSerializerOptions;
    }

    private static async Task<Hl7.Fhir.Model.Resource?> DeserializeFhirResource(HttpRequest request, JsonSerializerOptions? jsonSerializerOptions)
    {
      try
      {
        return await JsonSerializer.DeserializeAsync<Hl7.Fhir.Model.Resource>(request.Body, jsonSerializerOptions);
      }
      catch (DeserializationFailedException exception)
      {
        throw new FhirFatalException(System.Net.HttpStatusCode.BadRequest, "Body FHIR parsing failed: " + exception.Message);
      }
    }
  }
}
