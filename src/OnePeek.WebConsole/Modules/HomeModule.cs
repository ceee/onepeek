using Nancy;
using OnePeek.Api;
using OnePeek.Entities;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace OnePeek.WebConsole.Modules
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Configuration.UseFiveStarSystem = true;
      OnePeekApi api = new OnePeekApi();

      Get["/", true] = async (ctx, token) =>
      {
        StoreSpotlightResults result = await api.GetSpotlight(StoreSpotlightType.Apps, StoreType.WindowsPhone8, StoreCultureType.EN_US);
        return View["Index", new
        {
          Spotlight = result
        }];
      };


      Get["/meta", true] = async (ctx, token) =>
      {
        AppMetadata meta = await api.GetMetadata(Request.Query["id"], StoreType.WindowsPhone8, StoreCultureType.EN_US);
        return View["Meta", meta];
      };


      Get["/reviews", true] = async (ctx, token) =>
      {
        AppReviews reviews = await api.GetReviews(Request.Query["id"], StoreType.WindowsPhone8, StoreCultureType.EN_US, StoreReviewSorting.Latest, Request.Query["prev"], Request.Query["next"]);
        return View["Reviews", reviews];
      };


      Get["/search", true] = async (ctx, token) =>
      {
        StoreSearchResults result = await api.Search(Request.Query["term"], StoreType.WindowsPhone8, StoreCultureType.EN_US);
        return View["Search", result];
      };


      Get["/ratings", true] = async (ctx, token) =>
      {
        var order = Request.Query["order"];
        IEnumerable<AppRating> ratings = await api.GetRatingsForAllCultures(Request.Query["id"], StoreType.WindowsPhone8, new System.Threading.CancellationTokenSource().Token, null);

        if (order == "rating")
        {
          ratings = ratings.OrderByDescending(x => x.AverageRating).ThenByDescending(x => x.RatingCount);
        }
        else if (order == "name")
        {
          ratings = ratings.OrderBy(x => x.Culture);
        }
        else
        {
          order = "count";
          ratings = ratings.OrderByDescending(x => x.RatingCount);
        }

        return View["Ratings", new
        {
          Order = order,
          Id = Request.Query["id"],
          Ratings = ratings
        }];
      };
    }
  }
}