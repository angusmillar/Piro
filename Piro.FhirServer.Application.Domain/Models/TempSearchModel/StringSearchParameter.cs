namespace Piro.FhirServer.Application.Domain.Models.TempSearchModel;

public class StringSearchParameter : SearchParameterBase
{
    public StringSearchParameter(int searchParameterId, string value, SearchParameterBase? chained) 
        : base(searchParameterId, chained)
    {
        Value = value;
    }

    public string Value { get; set; }
}