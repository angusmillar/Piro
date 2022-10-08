
extern alias R4;
extern alias Stu3;
//using Hl7.Fhir.Model;
using ModelR4 = R4.Hl7.Fhir.Model;
using ModelStu3 = Stu3.Hl7.Fhir.Model;
using Microsoft.AspNetCore.Mvc;


namespace Piro.FhirServer.Api.Controllers;

[Route("stu3/fhir")]
public class FhirStu3Controller : Controller
{
    // GET
    //#####################################################################
    //## |POST - CREATE| ##################################################
    //#####################################################################

    // POST: stu3/fhir/Patient
    [HttpPost("{resourceName}")]
    public async Task<ActionResult<Hl7.Fhir.Model.Resource>> Post(string resourceName, [FromBody]Hl7.Fhir.Model.Resource resource)
    {
        //if (resource == null) return BadRequest();
        
        if (string.IsNullOrWhiteSpace(resourceName)) return BadRequest();
 
        //resource.AddAnnotation(Hl7.Fhir.Rest.SummaryType.False);
        resource.AddAnnotation(Piro.FhirServer.Domain.Enums.FhirVersion.Stu3);
        
        await Task.CompletedTask;

        //Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
        return  StatusCode((int)System.Net.HttpStatusCode.OK, resource);
        
    }
}