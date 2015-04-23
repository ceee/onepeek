using OnePeek.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OnePeek.Api
{
  public interface IOnePeekApi
  {
    /// <summary>
    /// Returns a stream for a store image.
    /// </summary>
    /// <param name="urn">The urn (is part of the AppImage).</param>
    /// <param name="imageType">Crops the image accordingly.</param>
    /// <returns></returns>
    Task<Stream> GetImageAsStream(string urn, StoreImageType imageType = StoreImageType.None);

    /// <summary>
    /// Creates an URI from an image urn (included in the AppImage POCO).
    /// </summary>
    /// <param name="urn">The urn (is part of the AppImage).</param>
    /// <param name="imageType">Crops the image accordingly.</param>
    /// <returns></returns>
    Uri GetImageUri(string urn, StoreImageType imageType = StoreImageType.None);

    /// <summary>
    /// Get app description, images, publisher, rating and more for an app in the specified culture.
    /// </summary>
    /// <param name="appId">The ID of the app. Can be found in the dev portal or the store URI.</param>
    /// <param name="store">The store where the app is published.</param>
    /// <param name="storeCulture">Culture of the query (returns location specific metadata + ratings).</param>
    /// <returns></returns>
    Task<AppMetadata> GetMetadata(string appId, StoreType store, StoreCultureType storeCulture);

    /// <summary>
    /// Gets metadata for an app for all available cultures
    /// Warning: This method makes a request per culture (100+) which can take a while.
    /// </summary>
    /// <param name="appId">The ID of the app. Can be found in the dev portal or the store URI.</param>
    /// <param name="store">The store where the app is published.</param>
    /// <param name="ct">The canellation token.</param>
    /// <param name="progress">The progress event gets triggered as soon as new data arrives.</param>
    /// <returns></returns>
    Task<IEnumerable<AppMetadata>> GetMetadataForAllCultures(string appId, StoreType store, CancellationToken ct, IProgress<DownloadProgressChangedEventArgs> progress);

    /// <summary>
    /// Get app rating (count + average) in the specified culture.
    /// </summary>
    /// <param name="appId">The ID of the app. Can be found in the dev portal or the store URI.</param>
    /// <param name="store">The store where the app is published.</param>
    /// <param name="storeCulture">Culture of the query (returns location specific ratings).</param>
    /// <returns></returns>
    Task<AppRating> GetRating(string appId, StoreType store, StoreCultureType storeCulture);

    /// <summary>
    /// Gets ratings for an app for all available cultures
    /// Warning: This method makes a request per culture (100+) which can take a while.
    /// </summary>
    /// <param name="appId">The ID of the app. Can be found in the dev portal or the store URI.</param>
    /// <param name="store">The store where the app is published.</param>
    /// <param name="ct">The canellation token.</param>
    /// <param name="progress">The progress event gets triggered as soon as new data arrives.</param>
    /// <returns></returns>
    Task<IEnumerable<AppRating>> GetRatingsForAllCultures(string appId, StoreType store, CancellationToken ct, IProgress<DownloadProgressChangedEventArgs> progress);

    /// <summary>
    /// Get a list of reviews (up to 20 per request) for the specified app.
    /// </summary>
    /// <param name="appId">The ID of the app. Can be found in the dev portal or the store URI.</param>
    /// <param name="store">The store where the app is published.</param>
    /// <param name="storeCulture">Culture of the query (returns location specific metadata + ratings).</param>
    /// <param name="sorting">Sorting criteria.</param>
    /// <returns></returns>
    Task<AppReviews> GetReviews(string appId, StoreType store, StoreCultureType storeCulture, StoreReviewSorting sorting, string prevPageMarkerId = null, string nextPageMarkerId = null);
   
    /// <summary>
    /// Searches for apps based on a term (app name, keywords, ..)
    /// </summary>
    /// <param name="searchTerm">Search termn, is typically an app name or keyword (as used in the store interface).</param>
    /// <param name="store">The store where the app is published.</param>
    /// <param name="storeCulture">Culture of the query (returns location specific metadata + ratings).</param>
    /// <returns></returns>
    Task<StoreSearchResults> Search(string searchTerm, StoreType store, StoreCultureType storeCulture);
  }
}
