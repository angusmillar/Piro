using Piro.FhirServer.Domain.Enums;

namespace Piro.FhirServer.Domain.Interfaces.DomainModel
{
  public interface IServiceBaseUrl
  {
    int Id { get; set; }
    bool IsPrimary { get; set; }
    string Url { get; set; }
    public FhirVersion FhirVersionId { get; set; }
  }
}