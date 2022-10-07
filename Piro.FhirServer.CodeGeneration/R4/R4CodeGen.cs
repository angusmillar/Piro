extern alias R4;
using R4Model = R4.Hl7.Fhir.Model;
using System.Collections.Generic;

namespace Piro.FhirServer.CodeGeneration.R4
{
  public static class R4CodeGen
  {
    public static List<string> GetResourceNameList()
    {
      return R4Model.ModelInfo.SupportedResources;
    }
  }
}
