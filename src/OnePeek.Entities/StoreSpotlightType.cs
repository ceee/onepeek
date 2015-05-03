using System.ComponentModel.DataAnnotations;

namespace OnePeek.Entities
{
  public enum StoreSpotlightType
  {
    [Display(Name = "apps")]
    Apps,
    [Display(Name = "games")]
    Games
  }
}
