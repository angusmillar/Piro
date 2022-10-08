using Microsoft.AspNetCore.Mvc.Formatters;
using Piro.FhirServer.Api.Controllers;
using Piro.FhirServer.Domain.Enums;
using Piro.FhirServer.Domain.Exceptions;

namespace Piro.FhirServer.Api.ContentFormatters
{
  public abstract class FhirMediaTypeInputFormatter : TextInputFormatter
  {
    protected FhirMediaTypeInputFormatter() : base()
    {
      this.SupportedEncodings.Clear();
      this.SupportedEncodings.Add(UTF8EncodingWithoutBOM); // Encoding.UTF8);
    }

    /// <summary>
    /// This is set by the actual formatter (xml or json)
    /// </summary>
    protected FhirVersion? FhirMajorVersion { get; set; }

    protected void SetMajorFhirVersion(RouteValueDictionary requestRouteValues)
    {
      object? obj = requestRouteValues.GetValueOrDefault("controller");
      if (obj is not null && obj is string controllerClassNamePrefix)
      {
        if (nameof(FhirR4Controller).StartsWith(controllerClassNamePrefix))
        {
          FhirMajorVersion = FhirVersion.R4;
        }
        else if (nameof(FhirStu3Controller).StartsWith(controllerClassNamePrefix))
        {
          FhirMajorVersion = FhirVersion.Stu3;
        }
        else
        {
          throw new FhirFatalException(System.Net.HttpStatusCode.BadRequest,
            $"Unable to resolve which major version of FHIR is in use based on the Controller which received the request as there is no FHIR version mapped to controller type: {controllerClassNamePrefix}Controller");
        }
      }
    }
    
    protected override bool CanReadType(Type type)
    {
      if (typeof(Hl7.Fhir.Model.Resource).IsAssignableFrom(type))
      {
        FhirMajorVersion =  Piro.FhirServer.Domain.Enums.FhirVersion.Stu3;
        return true;
      }
      return false;
    }

  }
}
