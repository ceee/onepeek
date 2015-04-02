using Bender;
using OnePeek.Api.Extensions;
using OnePeek.Entities;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace OnePeek.Api
{
  public class AppRatingEndpoint : ApiBase
  {
    public async Task<AppReviews> GetReviews(string appId, StoreType store, StoreCultureType storeCulture, StoreReviewSorting sorting)
    {
      if (storeCulture == StoreCultureType.Unknown)
      {
        throw new ArgumentException("Please provide a valid store culture");
      }

      string xml = await ApiHttpClient.Instance.Get(
        EndpointUris.GetWindowsPhoneReviewsUri(appId, storeCulture.ToString(), sorting.ToString())
      );

      IEnumerable<XElement> xel = XDocument.Parse(xml).Elements().First().Descendants();

      AppReviews result = Deserialize.Xml<AppReviews>(xml);
      result.Id = appId;
      result.StoreType = store;
      result.StoreCultureType = storeCulture;
      result.Sorting = sorting;

      // parse markers
      result.PrevPageMarkerId = Utils.GetQueryPart(xel.FirstOrDefault(x => x.Name.LocalName == "link" && x.Attribute("rel").Value == "prev"), "href", "beforeMarker");
      result.NextPageMarkerId = Utils.GetQueryPart(xel.FirstOrDefault(x => x.Name.LocalName == "link" && x.Attribute("rel").Value == "next"), "href", "afterMarker");

      // create images
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

      return result;
    }
  }
}