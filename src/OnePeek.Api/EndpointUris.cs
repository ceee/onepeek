using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePeek.Api
{
  internal static class EndpointUris
  {
    private const string WINDOWSPHONE_METADATA_URI = "http://marketplaceedgeservice.windowsphone.com/v9/catalog/apps/{0}?os=8.10.14219.0&cc={1}&lang={2}";


    internal static Uri GetWindowsPhoneMetadataUri(string appId, string culture)
    {
      culture = culture.Replace('_', '-');
      string country = culture.Split('-')[1];
      string uriString = String.Format(WINDOWSPHONE_METADATA_URI, appId, country, culture);

      return new Uri(uriString, UriKind.Absolute);
    }
  }
}
