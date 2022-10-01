namespace Piro.FhirServer.Application.Domain.Models;

public class IndexString
{
#pragma warning disable CS8618
    private IndexString()
#pragma warning restore CS8618
    {
    }
    
    public IndexString(int? id, string value, int sourceResourceId, FhirResource sourceFhirResource)
    {
        Id = id;
        Value = value;
        SourceFhirResource = sourceFhirResource;
        SourceResourceId = sourceResourceId;
    }

    public int? Id { get; set; }
    public string Value { get; set; }
    public int SourceResourceId { get; set; }
    public FhirResource SourceFhirResource { get; set; }
}