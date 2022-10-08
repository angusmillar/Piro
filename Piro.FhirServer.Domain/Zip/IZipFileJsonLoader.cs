using Newtonsoft.Json;

namespace Piro.FhirServer.Domain.Zip
{
  public interface IZipFileJsonLoader
  {
    JsonReader Load(byte[] ZipFileBytes, string fileNameRequired);
  }
}