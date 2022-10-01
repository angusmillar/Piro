namespace Piro.FhirServer.Application.Domain.Models;

public class FhirResource
{
#pragma warning disable CS8618
    private FhirResource()
#pragma warning restore CS8618
    {
    }
    
    public FhirResource(int? id, string fhirId, int? resourceTypeId, ResourceType resourceType, List<IndexResourceReference> indexResourceReferenceList, List<IndexString> indexStringList, List<IndexResourceReference> backResourceReferenceIndexList)
    {
        Id = id;
        FhirId = fhirId;
        ResourceTypeId = resourceTypeId;
        ResourceType = resourceType;
        IndexResourceReferenceList = indexResourceReferenceList;
        IndexStringList = indexStringList;
        BackResourceReferenceIndexList = backResourceReferenceIndexList;
    }

    

    public int? Id { get; set; }
    public string FhirId { get; set; }
    public int? ResourceTypeId { get; set; }
    public ResourceType ResourceType { get; set; }
    public List<IndexResourceReference> IndexResourceReferenceList { get; set; }
    public List<IndexString> IndexStringList { get; set; }
    public List<IndexResourceReference> BackResourceReferenceIndexList { get; set; }
    
}