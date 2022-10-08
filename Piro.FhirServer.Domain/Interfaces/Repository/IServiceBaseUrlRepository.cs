using System.Threading.Tasks;
using Piro.FhirServer.Domain.Enums;
using Piro.FhirServer.Domain.Interfaces.DomainModel;

namespace Piro.FhirServer.Domain.Interfaces.Repository
{
  public interface IServiceBaseUrlRepository
  {
    Task<IServiceBaseUrl?> GetBy(FhirVersion fhirVersion, string url);
    Task<IServiceBaseUrl?> GetPrimary(FhirVersion fhirVersion);
    Task<IServiceBaseUrl> AddAsync(FhirVersion fhirVersion, string url, bool IsPrimary);
    Task SaveChangesAsync();
  }
}