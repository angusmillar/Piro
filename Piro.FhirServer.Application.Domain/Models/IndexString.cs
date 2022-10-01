namespace Piro.FhirServer.Application.Domain.Models;

public class IndexString : IndexBase
{
#pragma warning disable CS8618
    private IndexString(): base() { }
#pragma warning restore CS8618
    
    public IndexString(int? id, string value, int? resourceStoreId, ResourceStore resourceStore, int searchParameterId )
        :base(id, resourceStoreId, resourceStore, searchParameterId)
    {
        Value = value;
    }

    public string Value { get; set; }
}