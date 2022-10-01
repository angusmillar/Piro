namespace Piro.FhirServer.Application.Domain.Models;

public class IndexResourceReference
{
#pragma warning disable CS8618
    private IndexResourceReference()
#pragma warning restore CS8618
    {
    }
    
    public IndexResourceReference(int? id, string targetFhirId, string targetVersionId, ResourceType targetResourceType, int? targetResourceId, FhirResource? targetResource, FhirResource sourceFhirResource, int sourceResourceId)
    {
        Id = id;
        TargetFhirId = targetFhirId;
        TargetVersionId = targetVersionId;
        TargetResourceType = targetResourceType;
        TargetResourceId = targetResourceId;
        TargetResource = targetResource;
        SourceFhirResource = sourceFhirResource;
        SourceResourceId = sourceResourceId;
    }

    public int? Id { get; set; }
    public string TargetFhirId { get; set; }
    public string TargetVersionId { get; set; }
    
    public ResourceType TargetResourceType { get; set; }
    
    public int? TargetResourceId { get; set; }
    
    public FhirResource? TargetResource { get; set; }
    
    public FhirResource SourceFhirResource { get; set; }
    
    public int SourceResourceId { get; set; }
}       