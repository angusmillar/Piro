using Hl7.Fhir.Model;

namespace Piro.FhirServer.Fhir.R4.OperationOutCome
{
  public interface IR4OperationOutComeSupport
  {
    OperationOutcome GetError(string[] errorMessageList);
    OperationOutcome GetFatal(string[] errorMessageList);
    OperationOutcome GetInformation(string[] errorMessageList);
    OperationOutcome GetWarning(string[] errorMessageList);
  }
}