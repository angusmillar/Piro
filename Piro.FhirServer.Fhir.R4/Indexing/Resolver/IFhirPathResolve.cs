using Hl7.Fhir.ElementModel;

namespace Piro.FhirServer.Fhir.R4.Indexing.Resolver
{
  public interface IFhirPathResolve
  {
    ITypedElement Resolver(string url);
  }
}