namespace Piro.FhirServer.Application.Domain.Models;

public class IndexReference : IndexBase
{
#pragma warning disable CS8618
    private IndexReference() { }
#pragma warning restore CS8618
    
    public IndexReference(int? id, string fhirId, string? versionId, int resourceTypeId, ResourceType resourceType, int? targetResourceStoreId, ResourceStore? targetResourceStore, int? resourceStoreId, ResourceStore resourceStore,  int searchParameterId)
     :base(id, resourceStoreId, resourceStore, searchParameterId)
    {
        FhirId = fhirId;
        VersionId = versionId;
        ResourceTypeId = resourceTypeId;
        ResourceType = resourceType;
        TargetResourceStoreId = targetResourceStoreId;
        TargetResourceStore = targetResourceStore;
    }
    
    public string FhirId { get; set; }
    public string? VersionId { get; set; }
    public int ResourceTypeId { get; set; }
    public ResourceType ResourceType { get; set; }
    public int? TargetResourceStoreId { get; set; }
    public ResourceStore? TargetResourceStore { get; set; }
    
    
}       