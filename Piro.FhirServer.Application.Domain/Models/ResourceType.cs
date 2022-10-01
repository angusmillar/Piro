namespace Piro.FhirServer.Application.Domain.Models;

public class ResourceType
{
#pragma warning disable CS8618
    private ResourceType()
#pragma warning restore CS8618
    {
    }
    
    public ResourceType(int? id, string name)
    {
        Id = id;
        Name = name;
    }

    public int? Id { get; set; }

    public string Name { get; set; }
}
