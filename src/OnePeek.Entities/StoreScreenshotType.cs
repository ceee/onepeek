using System.ComponentModel.DataAnnotations;

namespace OnePeek.Entities
{
  public enum StoreScreenshotType
  {
    [Display(Name = "ws_icon_large")]
    Logo,
    [Display(Name = "ws_screenshot_small")]
    ScreenshotSmall,
    [Display(Name = "ws_screenshot_large")]
    ScreenshotLarge
  }
}
