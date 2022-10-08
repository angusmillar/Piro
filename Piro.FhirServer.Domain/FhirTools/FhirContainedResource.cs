
using System;
using System.Collections.Generic;
using System.Text;
using Piro.FhirServer.Domain.Enums;

#nullable disable 
namespace Piro.FhirServer.Domain.FhirTools
{
  public class FhirContainedResource : FhirResource
  {
    public FhirContainedResource(Enums.FhirVersion FhirVersion, Enums.ResourceType ResourceType, string ResourceId)      
      :base(FhirVersion)
    {
      this.ResourceId = ResourceId;      
      this.ResourceType = ResourceType;
    }

    public string ResourceId { get; private set; }
    public Enums.ResourceType ResourceType { get; private set; }
    public FhirResource FhirResource { get; private set; }

  }
}
