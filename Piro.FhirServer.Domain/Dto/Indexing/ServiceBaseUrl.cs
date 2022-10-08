﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Piro.FhirServer.Domain.Dto.Indexing
{
  public class ServiceBaseUrl 
  {
    public ServiceBaseUrl()
    {
      this.IsPrimary = false;
    }
    public int Id { get; set; }
    public string? Url { get; set; }
    public bool IsPrimary { get; set; }
  }
}
