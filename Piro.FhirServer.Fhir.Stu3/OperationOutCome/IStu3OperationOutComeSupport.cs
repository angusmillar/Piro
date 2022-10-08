using Hl7.Fhir.Model;

namespace Piro.FhirServer.Fhir.Stu3.OperationOutCome
{
  public interface IStu3OperationOutComeSupport
  {
    OperationOutcome GetError(string[] errorMessageList);
    OperationOutcome GetFatal(string[] errorMessageList);
    OperationOutcome GetInformation(string[] errorMessageList);
    OperationOutcome GetWarning(string[] errorMessageList);
  }
}