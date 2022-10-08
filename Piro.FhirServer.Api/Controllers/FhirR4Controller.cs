using Microsoft.AspNetCore.Mvc;

namespace Piro.FhirServer.Api.Controllers;

[Route("r4/fhir")]
[ApiController]
public class FhirR4Controller : ControllerBase
{
    //#####################################################################
    //## |POST - CREATE| ##################################################
    //#####################################################################

    // POST: stu3/fhir/Patient
    [HttpPost("{resourceName}")]
    public async Task<ActionResult<Hl7.Fhir.Model.Resource>> Post(string resourceName, [FromBody]Hl7.Fhir.Model.Resource resource)
    {
        //if (resource == null) return BadRequest();
        
        if (string.IsNullOrWhiteSpace(resourceName)) return BadRequest();

        await Task.CompletedTask;

        resource.AddAnnotation(Hl7.Fhir.Rest.SummaryType.False);
        resource.AddAnnotation(Piro.FhirServer.Domain.Enums.FhirVersion.R4);
        
        //Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
        return  StatusCode((int)System.Net.HttpStatusCode.OK, resource);
        
    }
}

