namespace Piro.FhirServer.Application.Domain.Model;

//git test
public class ResourceStore
{
    public ResourceStore(int id, string type)
    {
        Id = id;
        Type = type;
    }

    public int Id { get; set; }
    public string Type { get; set; }
}