using System;
using System.Collections.Generic;

namespace OnePeek.Entities
{
  public partial class AppReviews
  {
    /// <summary>
    /// The ID of the review list.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Whether the result contains no results.
    /// </summary>
    public bool IsEmpty { get; set; }

    /// <summary>
    /// Last modified date of the resource (by Microsoft).
    /// </summary>
    public DateTime? StoreDataModifiedDate { get; set; }

    /// <summary>
    /// The type of the store (WP or Windows 8/10)
    /// </summary>
    public StoreType StoreType { get; set; }

    /// <summary>
    /// The culture is relevant for the review results,
    /// as they are unique per country
    /// </summary>
    public StoreCultureType StoreCultureType { get; set; }

    /// <summary>
    /// How to sort the ratings.
    /// shouldn't change when making further requests with a provided marker.
    /// </summary>
    public StoreReviewSorting Sorting { get; set; }

    /// <summary>
    /// The marker can be passed in the next request to get the previous page of reviews.
    /// </summary>
    public string PrevPageMarkerId { get; set; }

    /// <summary>
    /// The marker can be passed in the next request to get the next page of reviews.
    /// </summary>
    public string NextPageMarkerId { get; set; }

    /// <summary>
    /// List of reviews (max. 20 at the moment).
    /// </summary>
    public IEnumerable<AppReview> Reviews { get; set; }
  }


  public partial class AppReview
  {
    /// <summary>
    /// The ID of the review.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The date the review was created.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// The author who created the review.
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// The text the author has written in the review.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// The rating for the app from 1-10 (can be changed to 1-5 with Configuration.UseFiveStarSystem).
    /// </summary>
    public byte Rating { get; set; }

    /// <summary>
    /// The device model which was used for writing the review (and using the app).
    /// </summary>
    public string Device { get; set; }

    /// <summary>
    /// The current app version the reviewer has installed.
    /// Caution: This seems to be pretty random sometimes.
    /// </summary>
    public string AppVersion { get; set; } 
  }
}
