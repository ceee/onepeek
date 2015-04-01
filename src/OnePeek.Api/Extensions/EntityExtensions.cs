using OnePeek.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePeek.Api.Extensions
{
  public static class EntityExtensions
  {
    public static Uri GetUri(this AppImage appImage, StoreImageType imageType = StoreImageType.None)
    {
      return EndpointUris.GetWindowsPhoneImageUri(appImage.Urn, imageType.GetEnumDisplayName());
    }
  }
}
