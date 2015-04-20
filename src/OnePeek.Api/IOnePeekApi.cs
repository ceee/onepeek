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
    Task<Stream> GetImageAsStream(string urn, StoreImageType imageType = StoreImageType.None);
    Uri GetImageUri(string urn, StoreImageType imageType = StoreImageType.None);
    Task<AppMetadata> GetMetadata(string appId, StoreType store, StoreCultureType storeCulture);
    Task<IEnumerable<AppMetadata>> GetMetadataForAllCultures(string appId, StoreType store, CancellationToken ct, IProgress<DownloadProgressChangedEventArgs> progress);
    Task<AppRating> GetRating(string appId, StoreType store, StoreCultureType storeCulture);
    Task<IEnumerable<AppRating>> GetRatingsForAllCultures(string appId, StoreType store, CancellationToken ct, IProgress<DownloadProgressChangedEventArgs> progress);
    Task<AppReviews> GetReviews(string appId, StoreType store, StoreCultureType storeCulture, StoreReviewSorting sorting, string prevPageMarkerId = null, string nextPageMarkerId = null);
    Task<StoreSearchResults> Search(string searchTerm, StoreType store, StoreCultureType storeCulture);
  }
}
