using System;
using System.Collections.Generic;
using System.Text;

namespace Piro.FhirServer.Domain.Dto.Indexing
{
  public class IndexDateTime : IndexBase
  {
    public IndexDateTime(int fkSearchParameterId) 
      : base(fkSearchParameterId)
    {
    }

    public DateTime? Low { get; set; }
    public DateTime? High { get; set; }
  }
}
