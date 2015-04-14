using System.Xml.Serialization;

namespace OnePeek.Entities
{
  [XmlRoot("feed")]
  public partial class AppRating
  {
    /// <summary>
    /// Defines the culture where the rating applies to.
    /// </summary>
    public StoreCultureType Culture { get; set; }

    /// <summary>
    /// Average rating of the app from 1-10 (can be changed to 1-5 with Configuration.UseFiveStarSystem).
    /// Is dependent on the current culture.
    /// </summary>
    public float AverageRating { get; set; }

    /// <summary>
    /// Count of all ratings yet.
    /// Is dependent on the current culture.
    /// </summary>
    [XmlElement("userRatingCount")]
    public int RatingCount { get; set; }
  }
}
