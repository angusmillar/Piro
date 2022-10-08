using System.Collections.Generic;
using Piro.FhirServer.Domain.Exceptions;

namespace Piro.FhirServer.Domain.Enums
{
  public abstract class MapBase<InputEnumType, ReturnEnumType> 
    where ReturnEnumType : System.Enum
    where InputEnumType : System.Enum
  {
    protected abstract Dictionary<InputEnumType, ReturnEnumType> ForwardMap { get; }
    protected abstract Dictionary<ReturnEnumType, InputEnumType> ReverseMap { get; }

    public ReturnEnumType GetForward(InputEnumType value)
    {
      if (ForwardMap.ContainsKey(value))
      {
        return ForwardMap[value];
      }
      else
      {
        string Message = $"Unable to convert {nameof(value)} of type {value.GetType().Name} enum to the required return type.";
        throw new FhirFatalException(System.Net.HttpStatusCode.InternalServerError, Message);
      }
    }

    public InputEnumType GetReverse(ReturnEnumType value)
    {
      if (ReverseMap.ContainsKey(value))
      {
        return ReverseMap[value];
      }
      else
      {
        string Message = $"Unable to convert {nameof(value)} of type {value.GetType().Name} enum to the required return type.";
        throw new FhirFatalException(System.Net.HttpStatusCode.InternalServerError, Message);
      }
    }
  }

}
