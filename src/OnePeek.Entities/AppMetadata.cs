using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePeek.Entities
{
  public class AppMetadata
  {
    public DateTime? StoreDataModifiedDate { get; set; }

    public string Name { get; set; }

    public string Urn { get; set; }

    public string Id { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string Summary { get; set; }

    public string UpdateSummary { get; set; }

    public AppVisibilityStatus VisibilityStatus { get; set; }

    public AppPublisher Publisher { get; set; }

    public AppRating Rating { get; set; }

    public bool IsUniversal { get; set; }
  }

  public enum AppVisibilityStatus
  {
    Unknown,
    Live
  }
}
