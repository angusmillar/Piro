using System.Collections.Generic;
using Piro.FhirServer.CodeGeneration.Stu3;
using Piro.FhirServer.CodeGeneration.R4;

namespace Piro.FhirServer.CodeGeneration.T4Templates.ResourceName
{
  public class ResourceNameGen
  {
    public Dictionary<string, int> Dic { get; set; }
    public ResourceNameGen()
    {
      Dic = new Dictionary<string, int>();
      var counter = 1;
      Dic.Add("Resource", counter);
      counter++;
      Dic.Add("DomainResource", counter);
      counter++;
      foreach (var resourceName in Stu3CodeGen.GetResourceNameList())
      {
        Dic.Add(resourceName, counter);
        counter++;
      }
      foreach (string resourceName in R4CodeGen.GetResourceNameList())
      {
        if (!Dic.ContainsKey(resourceName))
        {
          Dic.Add(resourceName, counter);
          counter++;
        }
      }
    }
  }
}
