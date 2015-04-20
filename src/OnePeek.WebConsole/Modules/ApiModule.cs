using Nancy;
using OnePeek.Api;
using OnePeek.Entities;
using System.Collections.Generic;
using System.IO;

namespace OnePeek.WebConsole.Modules
{
  public class ApiModule : NancyModule
  {
    public ApiModule() : base("api/")
    {
      OnePeekApi api = new OnePeekApi();

      Get["/meta/{id}", true] = async (ctx, token) =>
      {
        AppMetadata meta = await api.GetMetadata(ctx.id, StoreType.WindowsPhone8, StoreCultureType.EN_US);
        return Response.AsJson(meta);
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