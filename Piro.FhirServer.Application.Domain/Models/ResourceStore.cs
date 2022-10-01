namespace Piro.FhirServer.Application.Domain.Models;

public class ResourceStore : DbBase
{
#pragma warning disable CS8618
    private ResourceStore()
#pragma warning restore CS8618
    {
    }
    
    public ResourceStore(int? id, string fhirId, int resourceTypeId, ResourceType resourceType, List<IndexReference> referenceIndexList, List<IndexString> stringIndexList, List<IndexReference> backResourceReferenceIndexList)
    {
        Id = id;
        FhirId = fhirId;
        ResourceTypeId = resourceTypeId;
        ResourceType = resourceType;
        ReferenceIndexList = referenceIndexList;
        StringIndexList = stringIndexList;
        BackResourceReferenceIndexList = backResourceReferenceIndexList;
    }

    

    public int? Id { get; set; }
    public string FhirId { get; set; }
    public int ResourceTypeId { get; set; }
    public ResourceType ResourceType { get; set; }
    public List<IndexReference> ReferenceIndexList { get; set; }
    public List<IndexString> StringIndexList { get; set; }
    public List<IndexReference> BackResourceReferenceIndexList { get; set; }
    
}