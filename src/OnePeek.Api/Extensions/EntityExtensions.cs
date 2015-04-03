using OnePeek.Entities;
using System;

namespace OnePeek.Api.Extensions
{
  public static class EntityExtensions
  {
    /// <summary>
    /// Creates an URI from an image.
    /// </summary>
    /// <param name="appImage">The appImage is returned as part of API endpoint requests.</param>
    /// <param name="imageType">Crops the image accordingly.</param>
    /// <returns></returns>
    public static Uri GetUri(this AppImage appImage, StoreImageType imageType = StoreImageType.None)
    {
      return EndpointUris.GetWindowsPhoneImageUri(appImage.Urn, imageType.GetEnumDisplayName());
    }
  }
}
