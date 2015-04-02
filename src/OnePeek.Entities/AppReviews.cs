using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OnePeek.Entities
{
  [XmlRoot("feed")]
  public partial class AppReviews
  {
    public string Id { get; set; }

    [XmlElement("updated")]
    public DateTime? StoreDataModifiedDate { get; set; }

    public StoreType StoreType { get; set; }

    public StoreCultureType StoreCultureType { get; set; }

    public StoreReviewSorting Sorting { get; set; }

    public string PrevPageMarkerId { get; set; }

    public string NextPageMarkerId { get; set; }

    public IEnumerable<AppReview> Reviews { get; set; }
  }


  [XmlRoot("entry")]
  public partial class AppReview
  {
    [XmlElement("reviewId")]
    public string Id { get; set; }

    [XmlElement("updated")]
    public DateTime CreatedDate { get; set; }

    [XmlElement("name")]
    public string Author { get; set; }

    [XmlElement("content")]
    public string Text { get; set; }

    [XmlElement("userRating")]
    public byte Rating { get; set; }

    [XmlElement("device")]
    public string Device { get; set; }

    [XmlElement("productVersion")]
    public string AppVersion { get; set; } 
  }
}
