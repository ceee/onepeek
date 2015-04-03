using System;

namespace OnePeek.Api
{
  internal static class EndpointUris
  {
    public const string WINDOWSPHONE_IMAGE_URI = "http://cdn.marketplaceimages.windowsphone.com/v8/images/{0}";

    public const string WINDOWSPHONE_METADATA_URI = "http://marketplaceedgeservice.windowsphone.com/v9/catalog/apps/{0}?os=8.10.14219.0&cc={1}&lang={2}";

    public const string WINDOWSPHONE_REVIEWS_URI = "http://marketplaceedgeservice.windowsphone.com/v9/ratings/product/{0}/reviews?os=8.10.14219.0&cc={1}&lang={2}&dm=RM-1045_1012&chunksize=20&skuId=c1424839-be1e-40eb-8bc3-b2730db30b62&orderBy={3}";



    internal static Uri GetWindowsPhoneMetadataUri(string appId, string culture)
    {
      culture = culture.Replace('_', '-');
      string country = culture.Split('-')[1];
      return Uri(WINDOWSPHONE_METADATA_URI, appId, country, culture);
    }



    internal static Uri GetWindowsPhoneImageUri(string urn, string type)
    {
      return Uri(WINDOWSPHONE_IMAGE_URI, urn.Replace("urn:uuid:", "") + (!String.IsNullOrWhiteSpace(type) ? "?imageType=" + type : ""));
    }



    internal static Uri GetWindowsPhoneReviewsUri(string appId, string culture, string orderBy, string prevPageMarkerId = null, string nextPageMarkerId = null)
    {
      culture = culture.Replace('_', '-');
      string country = culture.Split('-')[1];
      string affix = String.Empty;

      if (!String.IsNullOrWhiteSpace(prevPageMarkerId))
      {
        affix = "&beforeMarker=" + prevPageMarkerId;
      }
      else if (!String.IsNullOrWhiteSpace(nextPageMarkerId))
      {
        affix = "&afterMarker=" + nextPageMarkerId;
      }

      return Uri(WINDOWSPHONE_REVIEWS_URI + affix, appId, country, culture, orderBy);
    }



    private static Uri Uri(string template, params string[] replacements)
    {
      string uriString = String.Format(template, replacements);
      return new Uri(uriString, UriKind.Absolute);
    }
  }
}
