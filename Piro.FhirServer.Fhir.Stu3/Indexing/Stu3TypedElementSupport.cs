using Piro.FhirServer.Domain.Enums;
using Piro.FhirServer.Domain.FhirTools;
using Hl7.Fhir.ElementModel;
using Hl7.FhirPath;
using System;
using System.Collections.Generic;

namespace Piro.FhirServer.Fhir.Stu3.Indexing
{
  public class Stu3TypedElementSupport : IStu3TypedElementSupport
  {
    

    public IEnumerable<ITypedElement>? Select(IFhirResourceStu3 fhirResource, string Expression)
    {
      ITypedElement TypedElement = fhirResource.Stu3.ToTypedElement();
      //FhirPathCompiler.DefaultSymbolTable.AddFhirExtensions();
      var oFhirEvaluationContext = new Hl7.Fhir.FhirPath.FhirEvaluationContext(TypedElement);
      //The resolve() function then also needs to be provided an external resolver delegate that performs the resolve
      //that delegate can be set as below. Here I am providing my own implementation 'IPyroFhirPathResolve.Resolver' 
      //oFhirEvaluationContext.ElementResolver = IPyroFhirPathResolve.Resolver;     
      try
      {
        return TypedElement.Select(Expression, oFhirEvaluationContext);        
      }
      catch (Exception Exec)
      {
        throw new Piro.FhirServer.Domain.Exceptions.FhirFatalException(System.Net.HttpStatusCode.InternalServerError, $"Unable to evaluate the SearchParameter FhirPath expression of: {Expression} for FHIR {FhirVersion.Stu3.GetCode()}. See inner exception for more info.", Exec);        
      }
    }
  }
}
