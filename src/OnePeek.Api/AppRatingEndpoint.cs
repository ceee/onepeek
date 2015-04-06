using OnePeek.Api.Extensions;
using OnePeek.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnePeek.Api
{
  public class AppRatingEndpoint : ApiBase
  {
    /// <summary>
    /// Get a list of reviews (up to 20 per request) for the specified app.
    /// </summary>
    /// <param name="appId">The ID of the app. Can be found in the dev portal or the store URI.</param>
    /// <param name="store">The store where the app is published.</param>
    /// <param name="storeCulture">Culture of the query (returns location specific metadata + ratings).</param>
    /// <param name="sorting">Sorting criteria.</param>
    /// <returns></returns>
    public async Task<AppReviews> GetReviews(string appId, StoreType store, StoreCultureType storeCulture, StoreReviewSorting sorting, string prevPageMarkerId = null, string nextPageMarkerId = null)
    {
      if (storeCulture == StoreCultureType.Unknown)
      {
        throw new ArgumentException("Please provide a valid store culture");
      }

      string xml = await ApiHttpClient.Instance.Get(
        EndpointUris.GetWindowsPhoneReviewsUri(appId, storeCulture.ToString(), sorting.ToString(), prevPageMarkerId, nextPageMarkerId)
      );

      IEnumerable<XElement> xel = XDocument.Parse(xml).Elements().First().Descendants();

      AppReviews result = new AppReviews()
      {
        Id = appId,
        StoreType = store,
        StoreCultureType = storeCulture,
        Sorting = sorting,
        StoreDataModifiedDate = DateTime.Parse(xel.Get("updated"))
      };

      // parse markers
      result.PrevPageMarkerId = Utils.GetQueryPart(xel.FirstOrDefault(x => x.Name.LocalName == "link" && x.Attribute("rel").Value == "prev"), "href", "beforeMarker");
      result.NextPageMarkerId = Utils.GetQueryPart(xel.FirstOrDefault(x => x.Name.LocalName == "link" && x.Attribute("rel").Value == "next"), "href", "afterMarker");

      // append reviews
      result.Reviews = xel.Where(x => x.Name.LocalName == "entry").Select(x =>
      {
        IEnumerable<XElement> childs = x.Descendants();
        byte rating = (byte)childs.GetFloat("userRating");

        return new AppReview()
        {
          Id = childs.Get("reviewId"),
          CreatedDate = DateTime.Parse(childs.Get("updated")),
          Author = childs.FirstOrDefault(c => c.Name.LocalName == "author").Descendants().Get("name"),
          Text = childs.Get("content"),
          Rating = Configuration.UseFiveStarSystem ? (byte)(rating * 0.5) : rating,
          Device = childs.Get("device"),
          AppVersion = childs.Get("productVersion")
        };
      });

      result.IsEmpty = result.Reviews == null || !result.Reviews.Any();

      return result;
    }
  }
}