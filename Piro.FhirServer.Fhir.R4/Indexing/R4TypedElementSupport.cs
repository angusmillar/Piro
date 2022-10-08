using Piro.FhirServer.Domain.Enums;
using Piro.FhirServer.Domain.FhirTools;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.FhirPath;
using Hl7.Fhir.Model;
using Hl7.FhirPath;
using System;
using System.Collections.Generic;
using System.Text;
using Piro.FhirServer.Fhir.R4.Indexing.Resolver;

namespace Piro.FhirServer.Fhir.R4.Indexing
{
  public class R4TypedElementSupport : IR4TypedElementSupport
  {
    private readonly IFhirPathResolve IFhirPathResolve;
    public R4TypedElementSupport(IFhirPathResolve IFhirPathResolve)
    {
      this.IFhirPathResolve = IFhirPathResolve;
    }

    public IEnumerable<ITypedElement>? Select(IFhirResourceR4 fhirResource, string Expression)
    {
      ITypedElement TypedElement = fhirResource.R4.ToTypedElement();
      FhirPathCompiler.DefaultSymbolTable.AddFhirExtensions();
      //var oFhirEvaluationContext = new Hl7.Fhir.FhirPath.FhirEvaluationContext(TypedElement);
      var oFhirEvaluationContext = new Hl7.Fhir.FhirPath.FhirEvaluationContext(TypedElement);
      //The resolve() function then also needs to be provided an external resolver delegate that performs the resolve
      //that delegate can be set as below. Here I am providing my own implementation 'IPyroFhirPathResolve.Resolver' 
      oFhirEvaluationContext.ElementResolver = IFhirPathResolve.Resolver;

      try
      {
        return TypedElement.Select(Expression, oFhirEvaluationContext);
      }
      catch (Exception Exec)
      {
        throw new Piro.FhirServer.Domain.Exceptions.FhirFatalException(System.Net.HttpStatusCode.InternalServerError, $"Unable to evaluate the SearchParameter FhirPath expression of: {Expression} for FHIR {FhirVersion.R4.GetCode()}. See inner exception for more info.", Exec);
      }
    }
  }
}
