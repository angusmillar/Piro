using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Domain.Repositories;

namespace Piro.FhirServer.Application.Repository.Repositories;
    public class ResourceStoreRepository : GenericRepository<ResourceStore>, IResourceStoreGetByFhirId, IResourceStoreAdd, IResourceStoreSearch
    {
        public ResourceStoreRepository(AppContext context) : base(context)
        {
        }

        public ResourceStore? Get(string fhirId)
        {
            return Context.ResourceStore.SingleOrDefault(x => x.FhirId == fhirId);
        }

        public new async Task Add(ResourceStore resourceStore)
        {  
            base.Add(resourceStore);
            await Context.SaveChangesAsync();
        }
        
        public IEnumerable<ResourceStore> Search()
        {
            return base.Find(x => 
                x.ReferenceIndexList.Any(q => q.ResourceTypeId == 2 && q.SearchParameterId == 200 && 
                                              q.TargetResourceStore != null && q.TargetResourceStore.ReferenceIndexList.Any(y => 
                                                  y.ResourceTypeId == 2 && y.SearchParameterId == 300 && 
                                                  y.TargetResourceStore != null && y.TargetResourceStore.StringIndexList.Any(q => 
                                                      q.Value == "AcmeTwo"))));
        }
    }
