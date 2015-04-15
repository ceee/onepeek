using Bender;
using OnePeek.Api.Extensions;
using OnePeek.Entities;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace OnePeek.Api
{
  public class AppMetadataEndpoint : ApiBase
  {
    /// <summary>
    /// Get app description, images, publisher, rating and more for an app in the specified culture.
    /// </summary>
    /// <param name="appId">The ID of the app. Can be found in the dev portal or the store URI.</param>
    /// <param name="store">The store where the app is published.</param>
    /// <param name="storeCulture">Culture of the query (returns location specific metadata + ratings).</param>
    /// <returns></returns>
    public async Task<AppMetadata> GetMetadata(string appId, StoreType store, StoreCultureType storeCulture)
    {
      if (storeCulture == StoreCultureType.Unknown || storeCulture == StoreCultureType.All)
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
      if (Configuration.UseFiveStarSystem)
      {
        result.Rating.AverageRating = (float)(result.Rating.AverageRating * 0.5);
      }

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



    /// <summary>
    /// Get app rating (count + average) in the specified culture.
    /// </summary>
    /// <param name="appId">The ID of the app. Can be found in the dev portal or the store URI.</param>
    /// <param name="store">The store where the app is published.</param>
    /// <param name="storeCulture">Culture of the query (returns location specific ratings).</param>
    /// <returns></returns>
    public async Task<AppRating> GetRating(string appId, StoreType store, StoreCultureType storeCulture)
    {
      if (storeCulture == StoreCultureType.Unknown || storeCulture == StoreCultureType.All)
      {
        throw new ArgumentException("Please provide a valid store culture");
      }

      AppRating result = new AppRating();
      result.Culture = storeCulture;

      try
      {
        string xml = await ApiHttpClient.Instance.Get(
          EndpointUris.GetWindowsPhoneMetadataUri(appId, storeCulture.ToString())
        );

        IEnumerable<XElement> xel = XDocument.Parse(xml).Elements().First().Descendants();

        // update rating
        result.RatingCount = Convert.ToInt32(xel.Get("userRatingCount"));
        result.AverageRating = xel.GetFloat("averageUserRating");
        if (Configuration.UseFiveStarSystem)
        {
          result.AverageRating = (float)(result.AverageRating * 0.5);
        }

        return result;
      }
      catch
      {
        result.RatingNotAvailable = true;
        return result;
      }
    }



    /// <summary>
    /// Creates an URI from an image urn (included in the AppImage POCO).
    /// </summary>
    /// <param name="urn">The urn (is part of the AppImage).</param>
    /// <param name="imageType">Crops the image accordingly.</param>
    /// <returns></returns>
    public Uri GetImageUri(string urn, StoreImageType imageType = StoreImageType.None)
    {
      string type = imageType.GetEnumDisplayName();
      return EndpointUris.GetWindowsPhoneImageUri(urn, type);
    }



    /// <summary>
    /// Returns a stream for a store image.
    /// </summary>
    /// <param name="urn">The urn (is part of the AppImage).</param>
    /// <param name="imageType">Crops the image accordingly.</param>
    /// <returns></returns>
    public async Task<Stream> GetImageAsStream(string urn, StoreImageType imageType = StoreImageType.None)
    {
      string type = imageType.GetEnumDisplayName();
      Uri uri = EndpointUris.GetWindowsPhoneImageUri(urn, type);
      return await ApiHttpClient.Instance.GetStream(uri);
    }



    public async Task<IEnumerable<AppMetadata>> GetMetadataForAllCultures(string appId, StoreType store, CancellationToken ct, IProgress<DownloadProgressChangedEventArgs> progress)
    {
      IEnumerable<StoreCultureType> cultures = Enum.GetValues(typeof(StoreCultureType))
        .Cast<StoreCultureType>()
        .Where(x => x != StoreCultureType.All && x != StoreCultureType.Unknown);

      IEnumerable<Task<AppMetadata>> tasks = cultures.Select(culture =>
      {
        return GetMetadata(appId, store, culture);
      });

      return await Task.WhenAll(tasks).ConfigureAwait(false);
    }


    public async Task<IEnumerable<AppRating>> GetRatingsForAllCultures(string appId, StoreType store, CancellationToken ct, IProgress<DownloadProgressChangedEventArgs> progress)
    {
      IEnumerable<StoreCultureType> cultures = Enum.GetValues(typeof(StoreCultureType))
        .Cast<StoreCultureType>()
        .Where(x => x != StoreCultureType.All && x != StoreCultureType.Unknown);

      IEnumerable<Task<AppRating>> tasks = cultures.Select(culture =>
      {
        return GetRating(appId, store, culture);
      });

      return await Task.WhenAll(tasks).ConfigureAwait(false);
    }
  }


  public class DownloadProgressChangedEventArgs : EventArgs { }
}
