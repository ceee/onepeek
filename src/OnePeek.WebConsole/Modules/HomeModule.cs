using Nancy;
using OnePeek.Api;
using OnePeek.Entities;
using System.IO;

namespace OnePeek.WebConsole.Modules
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Configuration.UseFiveStarSystem = true;
      AppRatingEndpoint ratingEndpoint = new AppRatingEndpoint();
      AppMetadataEndpoint metaEndpoint = new AppMetadataEndpoint();

      Get["/"] = ctx =>
      {
        return View["Index"];
      };

      Get["/meta", true] = async (ctx, token) =>
      {
        AppMetadata meta = await metaEndpoint.GetMetadata(Request.Query["id"], StoreType.WindowsPhone8, StoreCultureType.EN_US);
        return View["Meta", meta];
      };


      Get["/reviews", true] = async (ctx, token) =>
      {
        AppReviews reviews = await ratingEndpoint.GetReviews(Request.Query["id"], StoreType.WindowsPhone8, StoreCultureType.EN_US, StoreReviewSorting.Latest);
        return View["Reviews", reviews];
      };
    }
  }
}