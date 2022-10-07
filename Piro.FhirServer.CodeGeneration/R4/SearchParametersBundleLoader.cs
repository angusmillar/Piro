extern alias R4;
using R4Model = R4.Hl7.Fhir.Model;
using R4Serialization = R4.Hl7.Fhir.Serialization;
using System;
using System.IO;
using Piro.FhirServer.CodeGeneration.Zip;
using Hl7.Fhir.Model;
using Newtonsoft.Json;

namespace Piro.FhirServer.CodeGeneration.R4
{
  public class SearchParametersBundleLoader
  {
    public R4Model.Bundle Load()
    {
      string fhirDefinitionsZipFilePath;
      DirectoryInfo projectDirectory = Directory.GetParent(Environment.CurrentDirectory);
      if (projectDirectory?.Parent != null)
      {
         fhirDefinitionsZipFilePath = Path.Combine(projectDirectory.Parent.FullName, "bin", "Debug", "R4", "fhir.4.0.1.definitions.json.zip");  
      }
      else
      {
        throw new Exception($"Unable to resolve the parent directory.");
      }

      byte[] fileBytes = File.ReadAllBytes(fhirDefinitionsZipFilePath);
      const string zipFileName = "search-parameters.json";
      var zipFileJsonLoader = new ZipFileJsonLoader();
      var jsonReader = zipFileJsonLoader.Load(fileBytes, zipFileName);    
      try
      {
        var resource = ParseJson(jsonReader);
        if (resource is R4Model.Bundle bundle)
        {
          return bundle;
        }
        else
        {
          throw new Exception($"Exception thrown when casting the json resource to a Bundle from the R4 FHIR specification {zipFileName} file.");
        }
      }
      catch (Exception exec)
      {
        throw new Exception($"Exception thrown when de-serializing FHIR resource bundle from the R4 FHIR specification {zipFileName} file. See inner exception for more info.", exec);
      }
    }

    private static Resource ParseJson(JsonReader reader)
    {      
      try
      {
        var fhirJsonParser = new R4Serialization.FhirJsonParser();
        return fhirJsonParser.Parse<Resource>(reader);
      }
      catch (Exception oExec)
      {
        throw new Exception("Error parsing R4 json to FHIR Resource, See inner exception info more info", oExec);
      }
    }
  }
}

