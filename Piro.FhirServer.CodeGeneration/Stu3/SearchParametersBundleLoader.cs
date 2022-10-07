extern alias Stu3;
using Stu3Model = Stu3.Hl7.Fhir.Model;
using Stu3Serialization = Stu3.Hl7.Fhir.Serialization;
using System;
using System.IO;
using Piro.FhirServer.CodeGeneration.Zip;
using Newtonsoft.Json;

namespace Piro.FhirServer.CodeGeneration.Stu3
{
  public class SearchParametersBundleLoader
  {
    public Stu3Model.Bundle Load()
    {
      string fhirDefinitionsZipFilePath;
      DirectoryInfo projectDirectory = Directory.GetParent(Environment.CurrentDirectory);
      if (projectDirectory?.Parent != null)
      {
        fhirDefinitionsZipFilePath = Path.Combine(projectDirectory.Parent.FullName, "bin", "Debug", "Stu3", "fhir.3.0.2.definitions.json.zip");  
      }
      else
      {
        throw new Exception($"Unable to resolve the parent directory.");
      }

      var fileBytes = File.ReadAllBytes(fhirDefinitionsZipFilePath);
      const string zipFileName = "search-parameters.json";
      var zipFileJsonLoader = new ZipFileJsonLoader();
      var jsonReader = zipFileJsonLoader.Load(fileBytes, zipFileName);    
      try
      {        
        var resource = ParseJson(jsonReader);
        if (resource is Stu3Model.Bundle bundle)
        {
          return bundle;
        }
        else
        {
          throw new Exception($"Exception thrown when casting the json resource to a Bundle from the Stu3 FHIR specification {zipFileName} file.");
        }
      }
      catch (Exception exec)
      {
        throw new Exception($"Exception thrown when de-serializing FHIR resource bundle from the Stu3 FHIR specification {zipFileName} file. See inner exception for more info.", exec);
      }
    }

    private Hl7.Fhir.Model.Resource ParseJson(JsonReader reader)
    {
      try
      {
        var fhirJsonParser = new Stu3Serialization.FhirJsonParser();
        return fhirJsonParser.Parse<Hl7.Fhir.Model.Resource>(reader);
      }
      catch (Exception oExec)
      {
        throw new Exception("Error parsing R4 Json to FHIR Resource, See inner exception info more info", oExec);
      }
    }
  }
}

