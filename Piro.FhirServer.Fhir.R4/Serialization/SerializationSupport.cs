﻿using System;
using Piro.FhirServer.Domain.FhirTools;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Newtonsoft.Json;
using Piro.FhirServer.Fhir.R4.Enums;

namespace Piro.FhirServer.Fhir.R4.Serialization
{
  public class SerializationSupport : IR4SerializationToJson, IR4SerializationToXml, IR4SerializationToJsonBytes, IR4ParseJson
  {
    public string SerializeToXml(Resource resource,  Piro.FhirServer.Domain.Enums.SummaryType summaryType =  Piro.FhirServer.Domain.Enums.SummaryType.False)
    {
      SummaryTypeMap Map = new SummaryTypeMap();
      try
      {
        FhirXmlSerializer FhirXmlSerializer = new FhirXmlSerializer();
        return FhirXmlSerializer.SerializeToString(resource, Map.GetForward(summaryType));
      }
      catch (Exception oExec)
      {
        throw new  Piro.FhirServer.Domain.Exceptions.FhirFatalException(System.Net.HttpStatusCode.InternalServerError, oExec.Message);
      }
    }

    public Resource ParseJson(string jsonResource)
    {      
      try
      {
        FhirJsonParser FhirJsonParser = new FhirJsonParser();
        return FhirJsonParser.Parse<Resource>(jsonResource);
      }
      catch (Exception oExec)
      {
        throw new  Piro.FhirServer.Domain.Exceptions.FhirFatalException(System.Net.HttpStatusCode.InternalServerError, oExec.Message);
      }
    }

    public Resource ParseJson(JsonReader reader)
    {
      SummaryTypeMap Map = new SummaryTypeMap();
      try
      {
        FhirJsonParser FhirJsonParser = new FhirJsonParser();
        return FhirJsonParser.Parse<Resource>(reader);
      }
      catch (Exception oExec)
      {
        throw new  Piro.FhirServer.Domain.Exceptions.FhirFatalException(System.Net.HttpStatusCode.InternalServerError, oExec.Message);
      }
    }
    public string SerializeToJson(Resource resource,  Piro.FhirServer.Domain.Enums.SummaryType summaryType =  Piro.FhirServer.Domain.Enums.SummaryType.False)
    {
      SummaryTypeMap Map = new SummaryTypeMap();
      try
      {
        FhirJsonSerializer FhirJsonSerializer = new FhirJsonSerializer();
        FhirJsonSerializer.Settings.Pretty = true;

        return FhirJsonSerializer.SerializeToString(resource, Map.GetForward(summaryType));
      }
      catch (Exception oExec)
      {
        throw new  Piro.FhirServer.Domain.Exceptions.FhirFatalException(System.Net.HttpStatusCode.InternalServerError, oExec.Message);
      }
    }

    public byte[] SerializeToJsonBytes(IFhirResourceR4 fhirResource,  Piro.FhirServer.Domain.Enums.SummaryType summaryType =  Piro.FhirServer.Domain.Enums.SummaryType.False)
    {
      SummaryTypeMap Map = new SummaryTypeMap();
      try
      {
        FhirJsonSerializer FhirJsonSerializer = new FhirJsonSerializer(new SerializerSettings() { Pretty = false, AppendNewLine = false });
        return FhirJsonSerializer.SerializeToBytes(fhirResource.R4, Map.GetForward(summaryType));
      }
      catch (Exception oExec)
      {
        throw new  Piro.FhirServer.Domain.Exceptions.FhirFatalException(System.Net.HttpStatusCode.InternalServerError, oExec.Message);
      }
    }

  }
}
