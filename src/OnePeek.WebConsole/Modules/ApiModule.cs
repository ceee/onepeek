using Nancy;
using Newtonsoft.Json;
using OnePeek.Api;
using OnePeek.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Threading;

namespace OnePeek.WebConsole.Modules
{
  public class ApiModule : NancyModule
  {
    public ApiModule(IRootPathProvider rootProvider) : base("api/")
    {
      OnePeekApi api = new OnePeekApi();

      Get["/meta/{id}", true] = async (ctx, token) =>
      {
        AppMetadata meta = await api.GetMetadata(ctx.id, StoreType.WindowsPhone8, StoreCultureType.EN_US);
        return Response.AsJson(meta);
      };


      Post["/spotlight", true] = async (ctx, token) =>
      {
        IEnumerable<StoreSpotlightIdResults> apps1 = await api.GetSpotlightIdsForAllCultures(StoreSpotlightType.Apps, StoreType.WindowsPhone8, default(CancellationToken));
        IEnumerable<StoreSpotlightIdResults> games1 = await api.GetSpotlightIdsForAllCultures(StoreSpotlightType.Games, StoreType.WindowsPhone8, default(CancellationToken));

        Dictionary<string, string> apps = new Dictionary<string, string>();
        Dictionary<string, string> games = new Dictionary<string, string>();

        foreach (var result in apps1)
        {
          foreach (var id in result.Ids)
          {
            if (!apps.ContainsKey(id))
            {
              apps.Add(id, result.StoreCultureType.ToString());
            }
            else
            {
              apps[id] = apps[id] + "," + result.StoreCultureType.ToString();
            }
          }
        }

        foreach (var result in games1)
        {
          foreach (var id in result.Ids)
          {
            if (!games.ContainsKey(id))
            {
              games.Add(id, result.StoreCultureType.ToString());
            }
            else
            {
              games[id] = games[id] + "," + result.StoreCultureType.ToString();
            }
          }
        }

        File.WriteAllText(Path.Combine(rootProvider.GetRootPath(), "AppData", "apps-" + DateTime.Now.ToString("yyyy-MM-dd") + ".json"), JsonConvert.SerializeObject(apps));
        File.WriteAllText(Path.Combine(rootProvider.GetRootPath(), "AppData", "games-" + DateTime.Now.ToString("yyyy-MM-dd") + ".json"), JsonConvert.SerializeObject(games));

        return Response.AsText("ok");
      };


      Get["/reviews/{id}", true] = async (ctx, token) =>
      {      
        AppReviews reviews = await api.GetReviews(ctx.id, StoreType.WindowsPhone8, StoreCultureType.EN_US, StoreReviewSorting.Latest);
        return Response.AsJson(reviews);
      };


      Get["/ratings/{id}", true] = async (ctx, token) =>
      {
        IEnumerable<AppRating> ratings = await api.GetRatingsForAllCultures(ctx.id, StoreType.WindowsPhone8, new System.Threading.CancellationTokenSource().Token, null);
        return Response.AsJson(ratings);
      };


      Get["/image/{id}.jpg", true] = async (ctx, token) =>
      {
        Stream imageStream = await api.GetImageAsStream(ctx.id, StoreImageType.None);
        return Response.FromStream(imageStream, "image/jpeg");
      };
    }
  }
}