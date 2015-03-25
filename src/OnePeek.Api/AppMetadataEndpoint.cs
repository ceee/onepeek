using OnePeek.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePeek.Api
{
  public class AppMetadataEndpoint : ApiBase
  {
    public async Task<AppMetadata> GetMetadata(StoreType store, StoreCultureType storeCulture)
    {
      throw new NotImplementedException();
    }
  }
}
