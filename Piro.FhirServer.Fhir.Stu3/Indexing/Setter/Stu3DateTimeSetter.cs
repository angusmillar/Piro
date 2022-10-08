﻿using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Piro.FhirServer.Domain.Dto.Indexing;
using Piro.FhirServer.Domain.Enums;
using System;
using System.Collections.Generic;
using Piro.FhirServer.Fhir.Stu3.Indexing.Setter.Support;

namespace Piro.FhirServer.Fhir.Stu3.Indexing.Setter
{
  public class Stu3DateTimeSetter : IStu3DateTimeSetter
  {
    private readonly IStu3DateTimeIndexSupport IDateTimeIndexSupport;
    private readonly Piro.FhirServer.Domain.DateTimeTools.IFhirDateTimeFactory IFhirDateTimeFactory;

    private ITypedElement? TypedElement;
    private Piro.FhirServer.Domain.Enums.ResourceType ResourceType;
    private int SearchParameterId;
    private string? SearchParameterName;

    public Stu3DateTimeSetter(IStu3DateTimeIndexSupport IDateTimeIndexSupport, Piro.FhirServer.Domain.DateTimeTools.IFhirDateTimeFactory IFhirDateTimeFactory)
    {
      this.IDateTimeIndexSupport = IDateTimeIndexSupport;
      this.IFhirDateTimeFactory = IFhirDateTimeFactory;
    }

    public IList<IndexDateTime> Set(ITypedElement typedElement, Piro.FhirServer.Domain.Enums.ResourceType resourceType, int searchParameterId, string searchParameterName)
    {
      this.TypedElement = typedElement;
      this.ResourceType = resourceType;
      this.SearchParameterId = searchParameterId;
      this.SearchParameterName = searchParameterName;

      var ResourceIndexList = new List<IndexDateTime>();

      if (this.TypedElement is IFhirValueProvider FhirValueProvider && FhirValueProvider.FhirValue != null)
      {
        if (FhirValueProvider.FhirValue is Date Date)
        {
          SetDate(Date, ResourceIndexList);
        }
        else if (FhirValueProvider.FhirValue is Period Period)
        {
          SetPeriod(Period, ResourceIndexList);
        }
        else if (FhirValueProvider.FhirValue is FhirDateTime FhirDateTime)
        {
          SetDateTime(FhirDateTime, ResourceIndexList);
        }
        else if (FhirValueProvider.FhirValue is FhirString FhirString)
        {
          SetString(FhirString, ResourceIndexList);
        }
        else if (FhirValueProvider.FhirValue is Instant Instant)
        {
          SetInstant(Instant, ResourceIndexList);
        }
        else if (FhirValueProvider.FhirValue is Timing Timing)
        {
          SetTiming(Timing, ResourceIndexList);
        }
        else
        {
          throw new FormatException($"Unknown FhirType: {this.TypedElement.InstanceType} for the SearchParameter entity with the database key of: {this.SearchParameterId.ToString()} for a resource type of: {this.ResourceType.GetCode()} and search parameter name of: {this.SearchParameterName}");
        }

        return ResourceIndexList;
      }
      else
      {
        throw new FormatException($"Unknown Navigator FhirType: {this.TypedElement.InstanceType} for the SearchParameter entity with the database key of: {this.SearchParameterId.ToString()} for a resource type of: {this.ResourceType.GetCode()} and search parameter name of: {this.SearchParameterName}");
      }
    }

    private void SetTiming(Timing Timing, IList<IndexDateTime> ResourceIndexList)
    {
      IndexDateTime? DateTimeIndex = IDateTimeIndexSupport.GetDateTimeIndex(Timing, SearchParameterId);
      if (DateTimeIndex is object)
      {
        if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
        {
          ResourceIndexList.Add(DateTimeIndex);
        }
      }
    }
    private void SetInstant(Instant Instant, IList<IndexDateTime> ResourceIndexList)
    {
      if (Instant.Value.HasValue)
      {
        IndexDateTime? DateTimeIndex = IDateTimeIndexSupport.GetDateTimeIndex(Instant, this.SearchParameterId);
        if (DateTimeIndex is Object)
        {
          if (DateTimeIndex.Low != null || DateTimeIndex.High != null)
          {
            ResourceIndexList.Add(DateTimeIndex);
          }
        }
      }
    }
    private void SetString(FhirString FhirString, IList<IndexDateTime> ResourceIndexList)
    {
      if (Hl7.Fhir.Model.Date.IsValidValue(FhirString.Value) || FhirDateTime.IsValidValue(FhirString.Value))
      {
        if (IFhirDateTimeFactory.TryParse(FhirString.Value, out Piro.FhirServer.Domain.DateTimeTools.FhirDateTime? XFhirDateTime, out string? ErrorMessage))
        {
          var FhirDateTime = new FhirDateTime(new DateTimeOffset(XFhirDateTime!.DateTime));

          var DateTimeIndex = IDateTimeIndexSupport.GetDateTimeIndex(FhirDateTime, this.SearchParameterId);
          if (DateTimeIndex is object)
            ResourceIndexList.Add(DateTimeIndex);
        }
      }
    }
    private void SetDateTime(FhirDateTime FhirDateTime, IList<IndexDateTime> ResourceIndexList)
    {
      if (FhirDateTime.IsValidValue(FhirDateTime.Value))
      {

        IndexDateTime? IndexDateTime = IDateTimeIndexSupport.GetDateTimeIndex(FhirDateTime, this.SearchParameterId);
        if (IndexDateTime is object)
        {
          if (IndexDateTime.Low != null || IndexDateTime.High != null)
          {
            ResourceIndexList.Add(IndexDateTime);
          }
        }
      }
    }
    private void SetPeriod(Period Period, IList<IndexDateTime> ResourceIndexList)
    {
      IndexDateTime? IndexDateTime = IDateTimeIndexSupport.GetDateTimeIndex(Period, this.SearchParameterId);
      if (IndexDateTime is object)
      {
        if (IndexDateTime.Low != null || IndexDateTime.High != null)
        {
          ResourceIndexList.Add(IndexDateTime);
        }
      }
    }
    private void SetDate(Date Date, IList<IndexDateTime> ResourceIndexList)
    {
      if (Date.IsValidValue(Date.Value))
      {
        DateTime? dateTime = null;
        DateTimeOffset? dateTimeOffSet = Date.ToDateTimeOffset();
        if (dateTimeOffSet.HasValue)
        {
          dateTime = dateTimeOffSet.Value.ToUniversalTime().DateTime;  
        }
        
        
        
        
        IndexDateTime? IndexDateTime = IDateTimeIndexSupport.GetDateTimeIndex(Date, this.SearchParameterId);
        if (IndexDateTime is object)
        {
          if (IndexDateTime.Low != null || IndexDateTime.High != null)
          {
            ResourceIndexList.Add(IndexDateTime);
          }
        }
      }
    }



  }

}
