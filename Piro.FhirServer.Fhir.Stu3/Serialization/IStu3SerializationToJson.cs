﻿using Hl7.Fhir.Model;
//using Hl7.Fhir.Rest;

namespace Piro.FhirServer.Fhir.Stu3.Serialization
{
  public interface IStu3SerializationToJson
  {
    string SerializeToJson(Resource resource, Piro.FhirServer.Domain.Enums.SummaryType summaryType = Piro.FhirServer.Domain.Enums.SummaryType.False);
  }
}