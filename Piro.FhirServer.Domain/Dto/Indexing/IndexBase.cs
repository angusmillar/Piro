using System;
using System.Collections.Generic;
using System.Text;

namespace Piro.FhirServer.Domain.Dto.Indexing
{
  public abstract class IndexBase
  {
    public IndexBase(int fkSearchParameterId)
    {
      this.SearchParameterId = fkSearchParameterId;
    }

    public int SearchParameterId { get; set; }
    public int? ResourceStoreId { get; set; }    
   
  }
}
