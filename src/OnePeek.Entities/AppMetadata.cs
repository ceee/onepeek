using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnePeek.Entities
{
  [XmlRoot("feed")]
  public class AppMetadata
  {
    [XmlElement("updated")]
    public DateTime? StoreDataModifiedDate { get; set; }

    [XmlElement("title")]
    public string Name { get; set; }

    [XmlElement("id")]
    public string Urn { get; set; }

    public string Id { get; set; }

    [XmlElement("releaseDate")]
    public DateTime ReleaseDate { get; set; }

    [XmlElement("content")]
    public string Summary { get; set; }

    [XmlElement("whatsNew")]
    public string UpdateSummary { get; set; }

    [XmlElement("visibilityStatus")]
    public AppVisibilityStatus VisibilityStatus { get; set; }

    public AppPublisher Publisher { get; set; }

    public AppRating Rating { get; set; }

    [XmlElement("isUniversal")]
    public bool IsUniversal { get; set; }
  }

  public enum AppVisibilityStatus
  {
    Unknown,
    Live
  }
}
