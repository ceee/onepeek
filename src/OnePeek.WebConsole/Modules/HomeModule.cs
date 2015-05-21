using Nancy;
using OnePeek.Api;
using OnePeek.Entities;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System;

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
        StoreSpotlightResults apps = await api.GetSpotlight(StoreSpotlightType.Apps, StoreType.WindowsPhone8, StoreCultureType.EN_US);
        StoreSpotlightResults games = await api.GetSpotlight(StoreSpotlightType.Games, StoreType.WindowsPhone8, StoreCultureType.EN_US);

        return View["Index", new
        {
          Spotlight = apps,
          SpotlightGames = games
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


      Get["/spotlight", true] = async (ctx, token) =>
      {
        IEnumerable<StoreSpotlightIdResults> results = await api.GetSpotlightIdsForAllCultures(StoreSpotlightType.Apps, StoreType.WindowsPhone8, default(CancellationToken));

        Dictionary<string, int> count = results
          .SelectMany(x => x.Ids)
          .GroupBy(x => x)
          .OrderByDescending(x => x.Count())
          .ToDictionary(x => x.Key, x => x.Count());

        return View["Spotlight", count];
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
          Ratings = ratings,
          WorldwideRating = ratings.Where(x => !x.RatingNotAvailable && x.RatingCount > 0).Average(x => x.AverageRating),
          WorldwideCount = ratings.Sum(x => x.RatingCount)
        }];
      };
    }
  }
}