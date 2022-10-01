using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Domain.Repositories;
using Piro.FhirServer.Application.Services;

namespace Piro.FhirServer.Application.Runner;

public class LoadTestOne
{
    private readonly IResourceStoreService _resourceStoreService;
    private readonly IResourceTypeService _resourceTypeService;
    private readonly IResourceStoreSearch _resourceStoreSearch;
    

    public LoadTestOne(IResourceStoreService resourceStoreService, IResourceTypeService resourceTypeService, IResourceStoreSearch resourceStoreSearch)
    {
        _resourceStoreService = resourceStoreService;
        _resourceTypeService = resourceTypeService;
        this._resourceStoreSearch = resourceStoreSearch;
    }

    public void Search()
    {
        var resultList = _resourceStoreSearch.Search();
    }

    public async Task Load()
    {
        var patientResourceType = await GetResourceType("Patient");
        var organizationResourceType = await GetResourceType("Organization");
        
        ResourceStore orgTwoResourceStore = await AddOrganizationTwoResource(organizationResourceType);
        ResourceStore orgOneResourceStore = await AddOrganizationOneResource(organizationResourceType, orgTwoResourceStore);
        ResourceStore patientResourceStore = await AddPatientResource(patientResourceType, organizationResourceType, orgOneResourceStore);

       
    }

    private async Task<ResourceStore> AddOrganizationTwoResource(ResourceType organizationResourceType)
    {
        // First Patient Resource
        var fhirResource = new ResourceStore(
            id: null,
            fhirId: "Org-2",
            resourceTypeId: organizationResourceType.Id!.Value,
            resourceType: organizationResourceType,
            referenceIndexList: new List<IndexReference>(),
            stringIndexList: new List<IndexString>(),
            backResourceReferenceIndexList: new List<IndexReference>());
    
        var indexString = new IndexString(id: null, value: "AcmeTwo", resourceStoreId: null,
            resourceStore: fhirResource,
            searchParameterId: 500);
    
        fhirResource.StringIndexList.Add(indexString);
        
        await _resourceStoreService.Add(fhirResource);
        return fhirResource;
    }
    
    private async Task<ResourceStore> AddOrganizationOneResource(ResourceType organizationResourceType, ResourceStore orgTwoResourceStore)
    {
        // First Patient Resource
        var fhirResource = new ResourceStore(
            id: null,
            fhirId: "Org-1",
            resourceTypeId: organizationResourceType.Id!.Value,
            resourceType: organizationResourceType,
            referenceIndexList: new List<IndexReference>(),
            stringIndexList: new List<IndexString>(),
            backResourceReferenceIndexList: new List<IndexReference>());
    
        var indexString = new IndexString(id: null, value: "AcmeOne", resourceStoreId: null,
            resourceStore: fhirResource,
            searchParameterId: 400);
    
        var indexResourceReference = new IndexReference(
            id: null,
            fhirId: "Org-2",
            versionId: null,
            resourceTypeId: organizationResourceType.Id!.Value,
            resourceType: organizationResourceType,
            targetResourceStoreId: orgTwoResourceStore.Id,
            targetResourceStore: orgTwoResourceStore,
            resourceStoreId: null,
            resourceStore: fhirResource,
            searchParameterId: 300);
    
        fhirResource.StringIndexList.Add(indexString);
        fhirResource.ReferenceIndexList.Add(indexResourceReference);
        
        await _resourceStoreService.Add(fhirResource);
        return fhirResource;
    }
    
    private async Task<ResourceStore> AddPatientResource(ResourceType patientResourceType, ResourceType organizationResourceType, ResourceStore orgOneResourceStore)
    {
        // First Patient Resource
        var fhirResource = new ResourceStore(
            id: null,
            fhirId: "Pat-1",
            resourceTypeId: patientResourceType.Id!.Value,
            resourceType: patientResourceType,
            referenceIndexList: new List<IndexReference>(),
            stringIndexList: new List<IndexString>(),
            backResourceReferenceIndexList: new List<IndexReference>());
    
        var indexString = new IndexString(id: null, value: "Angus", resourceStoreId: null,
            resourceStore: fhirResource,
            searchParameterId: 100);
    
        var indexResourceReference = new IndexReference(
            id: null,
            fhirId: "Org-1",
            versionId: null,
            resourceTypeId: organizationResourceType.Id!.Value,
            resourceType: organizationResourceType,
            targetResourceStoreId: orgOneResourceStore.Id,
            targetResourceStore: orgOneResourceStore,
            resourceStoreId: null,
            resourceStore: fhirResource,
            searchParameterId: 200);
    
        fhirResource.StringIndexList.Add(indexString);
        fhirResource.ReferenceIndexList.Add(indexResourceReference);
        
        await _resourceStoreService.Add(fhirResource);
        return fhirResource;
    }

    private async Task<ResourceType> GetResourceType(string resourceName)
    {
        ResourceType? dbPatientResourceType = _resourceTypeService.GetByName(resourceName);
        if (dbPatientResourceType is null)
        {
            dbPatientResourceType = new ResourceType(id: null, name: resourceName);
            await _resourceTypeService.Add(dbPatientResourceType);
        }
        return dbPatientResourceType;
    }
}