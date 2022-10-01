namespace Piro.FhirServer.Application.Domain.Models;

public class IndexBase
{
#pragma warning disable CS8618
    protected IndexBase(): base() { }
#pragma warning restore CS8618
    
    public IndexBase(int? id, int? resourceStoreId, ResourceStore resourceStore, int searchParameterId)
    {
        ResourceStoreId = resourceStoreId;
        ResourceStore = resourceStore;
        SearchParameterId = searchParameterId;
        Id = id;
    }

    public int? Id { get; set; }
    public int? ResourceStoreId { get; set; }
    public ResourceStore ResourceStore { get; set; }
    public int SearchParameterId { get; set; }
}