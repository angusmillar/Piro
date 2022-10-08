using System;
using System.Collections.Generic;
using System.Text;

namespace Piro.FhirServer.Domain.Dto.Indexing
{
  public class IndexToken : IndexBase
  {
    public IndexToken(int fkSearchParameterId) 
      : base(fkSearchParameterId)
    {
    }

    public string? Code { get; set; }
    public string? System { get; set; }
  }
}
