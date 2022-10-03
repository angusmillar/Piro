namespace Piro.FhirServer.Application.Domain.Models.TempSearchModel;

public abstract class SearchParameterBase
{
    protected SearchParameterBase(int searchParameterId, SearchParameterBase? chained)
    {
        SearchParameterId = searchParameterId;
        Chained = chained;
    }

    public int SearchParameterId { get; set; }
    public SearchParameterBase? Chained { get; set; }

}