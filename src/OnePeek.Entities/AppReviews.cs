using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OnePeek.Entities
{
  public partial class AppReviews
  {
    public string Id { get; set; }

    public bool IsEmpty { get; set; }

    public DateTime? StoreDataModifiedDate { get; set; }

    public StoreType StoreType { get; set; }

    public StoreCultureType StoreCultureType { get; set; }

    public StoreReviewSorting Sorting { get; set; }

    public string PrevPageMarkerId { get; set; }

    public string NextPageMarkerId { get; set; }

    public IEnumerable<AppReview> Reviews { get; set; }
  }


  public partial class AppReview
  {
    public string Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public string Author { get; set; }

    public string Text { get; set; }

    public byte Rating { get; set; }

    public string Device { get; set; }

    public string AppVersion { get; set; } 
  }
}
