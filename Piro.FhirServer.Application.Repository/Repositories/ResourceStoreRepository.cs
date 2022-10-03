using System.Linq.Expressions;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Domain.Models.TempSearchModel;
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
        
        public IEnumerable<ResourceStore> Search1()
        {
            return base.Find(x => 
                x.ReferenceIndexList.Any(q => q.ResourceTypeId == 2 && q.SearchParameterId == 200 && 
                                              q.TargetResourceStore != null && q.TargetResourceStore.ReferenceIndexList.Any(y => 
                                                  y.ResourceTypeId == 2 && y.SearchParameterId == 300 && 
                                                  y.TargetResourceStore != null && y.TargetResourceStore.StringIndexList.Any(q => 
                                                      q.Value == "AcmeTwo"))));
        }
        
        public IEnumerable<ResourceStore> Search()
        {
            List<SearchParameterBase> searchParameterList = GetSearchParameters();
            Expression<Func<ResourceStore, bool>> predicate = GetResourceStorePredicate(searchParameterList);
            
            try
            {
              
                IQueryable<ResourceStore> result = Context.ResourceStore.AsExpandable().Where(predicate);

                var sql = result.ToQueryString();

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        

        private static List<SearchParameterBase> GetSearchParameters()
        {
            return new List<SearchParameterBase>()
            {
                //new StringSearchParameter(999, "Pat-1", null),
                new ReferenceSearchParameter(200, 2,
                    chained: new ReferenceSearchParameter(300, 2,
                        chained: new StringSearchParameter(500, "AcmeTwo", null)))
            };
        }

        private Expression<Func<ResourceStore, bool>> GetResourceStorePredicate(List<SearchParameterBase> searchParameterList)
        {
            ExpressionStarter<ResourceStore> predicate = PredicateBuilder.New<ResourceStore>();
            foreach (SearchParameterBase searchParameterBase in searchParameterList)
            {
                if (searchParameterBase.Chained is null)
                {
                    if (searchParameterBase is StringSearchParameter stringSearchParameter)
                    {
                        var stringIndexQuery = StringIndex(stringSearchParameter);
                        predicate = predicate.And(p => p.StringIndexList.Any(stringIndexQuery.Compile()));    
                    }
                    else if (searchParameterBase is ReferenceSearchParameter referenceSearchParameter)
                    {
                        var referenceIndexQuery = ReferenceIndex(referenceSearchParameter);
                        predicate = predicate.And(p => p.ReferenceIndexList.Any(referenceIndexQuery.Compile()));
                    }
                    else
                    {
                        throw new NotImplementedException("The other search types");
                    }
                }
                else if (searchParameterBase is ReferenceSearchParameter referenceSearchParameter)
                {
                    var chainedReferenceIndexQuery = ChainedReference(referenceSearchParameter);
                    predicate = predicate.And(p => p.ReferenceIndexList.Any(chainedReferenceIndexQuery.Compile()));
                }
                else
                {
                    throw new NotImplementedException("All Chained searchParameters must be ReferenceSearchParameters");
                }
                
            }
            return predicate;
        }
        
        private Expression<Func<ResourceStore, bool>> GetResourceStorePredicate2(List<SearchParameterBase> searchParameterList)
        {
            ExpressionStarter<ResourceStore> predicate = PredicateBuilder.New<ResourceStore>();
            foreach (SearchParameterBase searchParameterBase in searchParameterList)
            {
                if (searchParameterBase is StringSearchParameter stringSearchParameter)
                {
                    var stringIndexQuery = StringIndex(stringSearchParameter);
                    predicate = predicate.And(p => p.StringIndexList.Any(stringIndexQuery.Compile()));    
                }
                else if (searchParameterBase is ReferenceSearchParameter referenceSearchParameter)
                {
                    if (referenceSearchParameter.Chained is not null)
                    {
                        var chainedReferenceIndexQuery = ChainedReference(referenceSearchParameter);
                        predicate = predicate.And(p => p.ReferenceIndexList.Any(chainedReferenceIndexQuery.Compile()));
                    }
                    else
                    {
                        var referenceIndexQuery = ReferenceIndex(referenceSearchParameter);
                        predicate = predicate.And(p => p.ReferenceIndexList.Any(referenceIndexQuery.Compile()));
                    }
                }
                else
                {
                    throw new NotImplementedException();
                }
                
            }
            return predicate;
        }
        
        private Expression<Func<IndexReference,bool>> ReferenceIndex(ReferenceSearchParameter referenceSearchParameter)
        {
            return y =>
                y.ResourceTypeId == referenceSearchParameter.ResourceTypeId && 
                y.SearchParameterId == referenceSearchParameter.SearchParameterId;
        }

        private Expression<Func<IndexReference,bool>> ChainedReference(ReferenceSearchParameter referenceSearchParameter)
        {
            if (referenceSearchParameter.Chained is not null)
            {
                if (referenceSearchParameter.Chained is ReferenceSearchParameter chainedReferenceSearchParameter)
                {
                    if (chainedReferenceSearchParameter.Chained is not null)
                    {
                        return ChainedReference(chainedReferenceSearchParameter);    
                    }
                    else
                    {
                        return ReferenceIndex(chainedReferenceSearchParameter);
                    }
                }
                else if (referenceSearchParameter.Chained is StringSearchParameter chainedStringSearchParameter)
                {
                    var stringIndexQuery = StringIndex(chainedStringSearchParameter);
                    return y =>
                        y.ResourceTypeId == referenceSearchParameter.ResourceTypeId &&
                        y.SearchParameterId == referenceSearchParameter.SearchParameterId &&
                        y.TargetResourceStore != null &&
                        y.TargetResourceStore.StringIndexList.Any(stringIndexQuery.Compile());
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                return ReferenceIndex(referenceSearchParameter);
            }
        }

        private Expression<Func<IndexString,bool>> StringIndex(StringSearchParameter stringSearchParameter )
        {
            return x => 
                x.SearchParameterId == stringSearchParameter.SearchParameterId && 
                x.Value == stringSearchParameter.Value;
        }
    }
