using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using System.Linq;
using Piro.FhirServer.Domain.Exceptions;
using Piro.FhirServer.Api.Controllers;

namespace Piro.FhirServer.Api.ContentFormatters
{
  public class FhirVersionParameterFilter : IResultFilter
  {
    public void OnResultExecuted(ResultExecutedContext context)
    {
    }

    public void OnResultExecuting(ResultExecutingContext context)
    {
      switch (context.Controller)
      {
        case FhirR4Controller:
          context.HttpContext.Items.Add("FhirVersion", "4.0");
          break;
        case FhirStu3Controller:
          context.HttpContext.Items.Add("FhirVersion", "3.0");
          break;
        // case Controllers.AdminController:
        //   context.HttpContext.Items.Add("FhirVersion", "3.0");
        //   break;
        default:
          throw new FhirFatalException(System.Net.HttpStatusCode.InternalServerError, "Unable to resolve which major version of FHIR is in use.");
      }
    }
  }
}
