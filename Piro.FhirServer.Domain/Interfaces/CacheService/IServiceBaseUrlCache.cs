using System.Threading.Tasks;
using Piro.FhirServer.Domain.Enums;
using Piro.FhirServer.Domain.Interfaces.DomainModel;

namespace Piro.FhirServer.Domain.Interfaces.CacheService
{
  public interface IServiceBaseUrlCache
  {
    Task<IServiceBaseUrl?> GetAsync(FhirVersion fhirVersion, string url);
    Task<IServiceBaseUrl> GetPrimaryAsync(FhirVersion fhirVersion);
    Task RemoveAsync(FhirVersion fhirVersion, string url);
    Task RemovePrimaryAsync(FhirVersion fhirVersion, string url);
    Task SetPrimaryAsync(IServiceBaseUrl serviceBaseUrl);
    Task SetAsync(IServiceBaseUrl serviceBaseUrl);
  }
}