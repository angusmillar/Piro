namespace Piro.FhirServer.Domain.ApplicationConfig
{
  public interface IEnforceResourceReferentialIntegrity
  {
    bool EnforceRelativeResourceReferentialIntegrity { get; set; }
  }
}