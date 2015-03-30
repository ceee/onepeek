using Bender;
using OnePeek.Api.Extensions;
using OnePeek.Entities;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;

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

      try
      {
        //string entryXml = XDocument.Parse(xml).Descendants().FirstOrDefault(x => x.Name.LocalName == "entry").ToString();

        AppReviews result = Deserialize.Xml<AppReviews>(xml);
        result.Id = appId;
        result.StoreType = store;
        result.StoreCultureType = storeCulture;
        result.Sorting = sorting;
        return result;
      }
      catch (Exception exc)
      {
        Debug.WriteLine(exc.Message);
      }

      return null;
    }
  }
}