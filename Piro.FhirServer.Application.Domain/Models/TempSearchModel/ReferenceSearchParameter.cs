namespace Piro.FhirServer.Application.Domain.Models.TempSearchModel;

public class ReferenceSearchParameter : SearchParameterBase
{
    public ReferenceSearchParameter(int searchParameterId, int resourceTypeId, SearchParameterBase? chained) 
        : base(searchParameterId, chained)
    {
        ResourceTypeId = resourceTypeId;
    }
    public int ResourceTypeId { get; set; }
}