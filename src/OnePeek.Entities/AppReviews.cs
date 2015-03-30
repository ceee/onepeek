using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnePeek.Entities
{
  [XmlRoot("feed")]
  public class AppReviews
  {
    public string Id { get; set; }

    [XmlElement("updated")]
    public DateTime? StoreDataModifiedDate { get; set; }

    public StoreType StoreType { get; set; }

    public StoreCultureType StoreCultureType { get; set; }

    public StoreReviewSorting Sorting { get; set; }

    public string PrevPageMarkerId { get; set; }

    public string NextPageMarkerId { get; set; }

    public List<AppReview> Reviews { get; set; }
  }


  public class AppReview
  {
    public DateTime CreatedDate { get; set; }

    public string Author { get; set; }

    public string Text { get; set; }

    public float Rating { get; set; }

    public string Id { get; set; }

    public string Device { get; set; }

    public string AppVersion { get; set; } 
  }
}
