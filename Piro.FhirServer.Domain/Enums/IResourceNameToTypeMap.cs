namespace Piro.FhirServer.Domain.Enums
{
  public interface IResourceNameToTypeMap
  {
    ResourceType? GetResourceType(string resourceName);
  }
}