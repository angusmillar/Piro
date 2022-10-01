using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Domain.Repositories;

namespace Piro.FhirServer.Application.Repository.Repositories;
    public class ResourceStoreRepository : GenericRepository<ResourceStore>, IResourceStoreGetByFhirId, IResourceStoreAdd
    {
        public ResourceStoreRepository(AppContext context) : base(context)
        {
        }

        public ResourceStore? Get(string fhirId)
        {
            return Context.ResourceStore.SingleOrDefault(x => x.FhirId == fhirId);
        }

        public override void Add(ResourceStore resourceStore)
        {
            base.Add(resourceStore);
            Context.SaveChanges();
        }
    }
