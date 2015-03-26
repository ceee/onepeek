using System;

namespace OnePeek.Api
{
  internal static class EndpointUris
  {
    public const string WINDOWSPHONE_IMAGE_URI = "http://cdn.marketplaceimages.windowsphone.com/v8/images/{0}";

    public const string WINDOWSPHONE_METADATA_URI = "http://marketplaceedgeservice.windowsphone.com/v9/catalog/apps/{0}?os=8.10.14219.0&cc={1}&lang={2}";



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



    private static Uri Uri(string template, params string[] replacements)
    {
      string uriString = String.Format(template, replacements).ToLower();
      return new Uri(uriString, UriKind.Absolute);
    }
  }
}
