extern alias Stu3;
extern alias R4;
using R4Rest = R4.Hl7.Fhir.Rest;
using R4Model = R4.Hl7.Fhir.Model;
using Stu3Rest = Stu3.Hl7.Fhir.Rest;
using Stu3Model = Stu3.Hl7.Fhir.Model;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Piro.FhirServer.Domain.Exceptions;

namespace Piro.FhirServer.Api.ContentFormatters
{
  public static class FhirMediaType
  {
    // TODO: This class can be merged into HL7.Fhir.ContentType

    public const string XmlResource = "application/fhir+xml";
    public const string JsonResource = "application/fhir+json";
    public const string BinaryResource = "application/fhir+binary";
 
    public static Piro.FhirServer.Domain.Enums.FhirFormatType GetFhirFormatTypeFromAcceptHeader(string acceptHeaderValue)
    {
      var defaultType = Piro.FhirServer.Domain.Enums.FhirFormatType.json;
      if (string.IsNullOrWhiteSpace(acceptHeaderValue))
        return defaultType;

      Dictionary<string, Piro.FhirServer.Domain.Enums.FhirFormatType> mediaTypeDic = new Dictionary<string, Piro.FhirServer.Domain.Enums.FhirFormatType>();
      foreach (var mediaType in Hl7.Fhir.Rest.ContentType.XML_CONTENT_HEADERS)
        mediaTypeDic.Add(mediaType, Piro.FhirServer.Domain.Enums.FhirFormatType.xml);

      foreach (var mediaType in Hl7.Fhir.Rest.ContentType.JSON_CONTENT_HEADERS)
        mediaTypeDic.Add(mediaType, Piro.FhirServer.Domain.Enums.FhirFormatType.json);

      acceptHeaderValue = acceptHeaderValue.Trim();
      if (mediaTypeDic.ContainsKey(acceptHeaderValue))
      {
        return mediaTypeDic[acceptHeaderValue];
      }        
      else
      {
        return defaultType;
      }
    }

    public static string GetContentType(Type type, Piro.FhirServer.Domain.Enums.FhirFormatType format)
    {
      if (typeof(Hl7.Fhir.Model.Resource).IsAssignableFrom(type))
      {
        switch (format)
        {
          case Piro.FhirServer.Domain.Enums.FhirFormatType.json: return JsonResource;
          case Piro.FhirServer.Domain.Enums.FhirFormatType.xml: return XmlResource;
          default: return JsonResource;
        }
      }
      else
        return "application/octet-stream";
    }

    public static StringSegment GetMediaTypeHeaderValue(Type type, Piro.FhirServer.Domain.Enums.FhirFormatType format)
    {
      string mediatype = FhirMediaType.GetContentType(type, format);
      
      MediaTypeHeaderValue header = new MediaTypeHeaderValue(mediatype);
      header.CharSet = Encoding.UTF8.WebName;
      if (typeof(Hl7.Fhir.Model.Resource).IsAssignableFrom(type))
      {
        return new StringSegment(header.ToString() + "; FhirVersion=3.0");
      }
      // if (typeof(Stu3Model.Resource).IsAssignableFrom(type))
      // {        
      //   return new StringSegment(header.ToString() + "; FhirVersion=3.0");
      // }
      // else if (typeof(R4Model.Resource).IsAssignableFrom(type))
      // {
      //   return  new StringSegment(header.ToString() + "; FhirVersion=4.0");
      // }
      else
      {
        throw new FhirFatalException(System.Net.HttpStatusCode.BadRequest, "Unable to resolve which major version of FHIR is in use.");
      }
            
    }
  }
}
