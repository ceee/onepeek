using Bender;
using OnePeek.Api.Extensions;
using OnePeek.Entities;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace OnePeek.Api
{
  public class AppMetadataEndpoint : ApiBase
  {
    public async Task<AppMetadata> GetMetadata(string appId, StoreType store, StoreCultureType storeCulture)
    {
      if (storeCulture == StoreCultureType.Unknown)
      {
        throw new ArgumentException("Please provide a valid store culture");
      }

      string xml = await ApiHttpClient.Instance.Get(
        EndpointUris.GetWindowsPhoneMetadataUri(appId, storeCulture.ToString())
      );

      try
      {
        AppMetadata result = Deserialize.Xml<AppMetadata>(xml);
        result.Id = appId;
        return result;
      }
      catch (Exception exc)
      {
        Debug.WriteLine(exc.Message);
      }

      return null;
    }



    public Uri GetImageUri(string urn, StoreImageType imageType = StoreImageType.None)
    {
      string type = imageType.GetEnumDisplayName();
      return EndpointUris.GetWindowsPhoneImageUri(urn, type);
    }



    public async Task<Stream> GetImageAsStream(string urn, StoreImageType imageType = StoreImageType.None)
    {
      string type = imageType.GetEnumDisplayName();
      Uri uri = EndpointUris.GetWindowsPhoneImageUri(urn, type);
      return await ApiHttpClient.Instance.GetStream(uri);
    }
  }
}
