using System.Xml.Serialization;

namespace OnePeek.Entities
{
  [XmlRoot("feed")]
  public class AppRating
  {
    public float AverageRating { get; set; }

    [XmlElement("userRatingCount")]
    public int RatingCount { get; set; }
  }
}
