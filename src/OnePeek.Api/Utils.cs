using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace OnePeek.Api
{
  internal static class Utils
  {
    public static string GetQueryPart(XElement element, string attribute, string queryKey)
    {
      if (element == null)
      {
        return null;
      }

      XAttribute attr = element.Attribute(attribute);

      if (attr == null)
      {
        return null;
      }

      Match match = new Regex(queryKey + @"=([A-Za-z0-9\-\=]+)").Match(attr.Value);
      return match.Success ? match.Groups[1].Value : null;
    }
  }
}
