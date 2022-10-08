﻿using System;
using System.Collections.Generic;
using System.Text;
using Piro.FhirServer.Domain.Enums;

namespace Piro.FhirServer.Domain.Dto.Indexing
{
  public class IndexReference : IndexBase
  {
    public IndexReference(int fkSearchParameterId) 
      : base(fkSearchParameterId){ }

    public int? ServiceBaseUrlId { get; set; }
    public ServiceBaseUrl? ServiceBaseUrl { get; set; }    
    public ResourceType? ResourceTypeId { get; set; }    
    public string? ResourceId { get; set; }
    public string? VersionId { get; set; }
    public string? CanonicalVersionId { get; set; }
    
  }
}
