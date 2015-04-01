using Bender;
using OnePeek.Api.Extensions;
using OnePeek.Entities;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

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

      IEnumerable<XElement> xel = XDocument.Parse(xml).Elements().First().Descendants();

      // create metadatas
      AppMetadata result = Deserialize.Xml<AppMetadata>(xml);
      result.Id = appId;
      result.StoreType = store;
      result.StoreCultureType = storeCulture;

      // create publisher
      result.Publisher = Deserialize.Xml<AppPublisher>(xml);
      result.Publisher.Id = result.Publisher.Urn.Split(':').LastOrDefault();

      // create rating
      result.Rating = Deserialize.Xml<AppRating>(xml);
      result.Rating.AverageRating = xel.GetFloat("averageUserRating");

      // create images
      result.Images = Deserialize.Xml<AppMetadataImages>(xml);
      result.Images.Cleanup();
      result.Images.Screenshots = xel.Where(x => x.Name.LocalName == "screenshot").Select(x =>
      {
        IEnumerable<XElement> childs = x.Descendants();
        return new AppImage()
        { 
          Urn = childs.Get("id"),
          Rotation = childs.GetShort("orientation")
        };
      });

      return result;
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
