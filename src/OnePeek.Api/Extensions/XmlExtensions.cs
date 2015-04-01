using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace OnePeek.Api.Extensions
{
  internal static class XmlExtensions
  {
    public static string Get(this IEnumerable<XElement> elements, string name)
    {
      XElement element = elements.FirstOrDefault(x => x.Name.LocalName == name);
      return element != null ? element.Value : String.Empty;
    }

    public static float GetFloat(this IEnumerable<XElement> elements, string name)
    {
      string value = elements.Get(name);
      return !String.IsNullOrEmpty(value) ? float.Parse(value, CultureInfo.InvariantCulture) : 0;
    }

    public static short GetShort(this IEnumerable<XElement> elements, string name)
    {
      string value = elements.Get(name);
      return !String.IsNullOrEmpty(value) ? Int16.Parse(value) : (short)0;
    }
  }
}
