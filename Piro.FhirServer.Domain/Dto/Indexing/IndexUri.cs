using System;
using System.Collections.Generic;
using System.Text;

namespace Piro.FhirServer.Domain.Dto.Indexing
{
  public class IndexUri : IndexBase
  {
    public IndexUri(int fkSearchParameterId, string uri) 
      : base(fkSearchParameterId)
    {
      this.Uri = uri;
    }

    public string Uri { get; set; }
  }
}
