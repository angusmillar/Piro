using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Domain.Repositories;

namespace Piro.FhirServer.Application.Repository.Repositories;
    public class FhirResourceRepository : GenericRepository<FhirResource>, IGetResourceByFhirId, IAddFhirResource
    {
        public FhirResourceRepository(AppContext context) : base(context)
        {
        }

        public FhirResource? Get(string fhirId)
        {
            return Context.FhirResource.SingleOrDefault(x => x.FhirId == fhirId);
        }
    }
