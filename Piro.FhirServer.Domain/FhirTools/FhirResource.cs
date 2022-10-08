

using System;
using System.Collections.Generic;
using System.Text;
using Hl7.Fhir.Model;
using Piro.FhirServer.Domain.Exceptions;
using Piro.FhirServer.Domain.Enums;

#nullable disable 
namespace Piro.FhirServer.Domain.FhirTools
{
  public class FhirResource : IFhirResourceStu3, IFhirResourceR4
  {
    public FhirResource(Enums.FhirVersion FhirVersion)
    {
      _FhirVersion = FhirVersion;
    }
    private Enums.FhirVersion _FhirVersion;
    public Enums.FhirVersion FhirVersion 
    { 
      get
      {
        return _FhirVersion;
      }        
    }

    private Resource _Stu3;
    public Resource Stu3
    {
      get
      {
        if (this._FhirVersion == Enums.FhirVersion.R4)
        {
          string message = $"Internal server error, attempted to Get a {Enums.FhirVersion.Stu3.GetCode()} Resource from a {this.GetType().Name} object instance when the the class was instantated as a FHIR {Enums.FhirVersion.R4.GetCode()} version instance.";
          throw new FhirVersionFatalException(message);
        }
        return _Stu3;
      }
      set
      {
        if (this._FhirVersion == Enums.FhirVersion.R4)
        {
          string message = $"Internal server error, attempted to Set a {this.GetType().Name} object instances with a {Enums.FhirVersion.Stu3.GetCode()} Resource when the the class was instantated as a FHIR {Enums.FhirVersion.R4.GetCode()} version instance.";
          throw new FhirVersionFatalException(message);
        }
        _Stu3 = value;
      }
    }

    private Hl7.Fhir.Model.Resource _R4;
    public Hl7.Fhir.Model.Resource R4
    {
      get
      {
        if (FhirVersion == Enums.FhirVersion.Stu3)
        {
          string message = $"Internal server error, attempted to Get a {Enums.FhirVersion.R4.GetCode()} Resource from a {this.GetType().Name} object instance when the the class was instantated as a FHIR {Enums.FhirVersion.Stu3.GetCode()} version instance.";
          throw new FhirVersionFatalException(message);
        }
        return _R4;
      }
      set
      {
        if (FhirVersion == Enums.FhirVersion.Stu3)
        {
          string message = $"Internal server error, attempted to Set a {this.GetType().Name} object instances with a {Enums.FhirVersion.R4.GetCode()} Resource when the the class was instantated as a FHIR {Enums.FhirVersion.Stu3.GetCode()} version instance.";
          throw new FhirVersionFatalException(message);
        }
        _R4 = value;
      }
    }
  }
}
