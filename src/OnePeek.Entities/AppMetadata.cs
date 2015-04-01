using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OnePeek.Entities
{
  [XmlRoot("feed")]
  public partial class AppMetadata
  {
    public string Id { get; set; }

    public StoreType StoreType { get; set; }

    public StoreCultureType StoreCultureType { get; set; }

    [XmlElement("updated")]
    public DateTime? StoreDataModifiedDate { get; set; }

    [XmlElement("title")]
    public string Name { get; set; }

    [XmlElement("id")]
    public string Urn { get; set; }

    [XmlElement("releaseDate")]
    public DateTime ReleaseDate { get; set; }

    [XmlElement("content")]
    public string Text { get; set; }

    [XmlElement("whatsNew")]
    public string UpdateText { get; set; }

    [XmlElement("iapCount")]
    public int IAPCount { get; set; }

    [XmlElement("visibilityStatus")]
    public AppVisibilityStatus VisibilityStatus { get; set; }

    [XmlElement("privacyPolicyUrl")]
    public string PrivacyPolicyUri { get; set; }

    [XmlElement("isUniversal")]
    public bool IsUniversal { get; set; }

    public AppMetadataImages Images { get; set; }

    public AppPublisher Publisher { get; set; }

    public AppRating Rating { get; set; }
  }

  [XmlRoot("feed")]
  public partial class AppMetadataImages
  {
    [XmlElement("image")]
    public AppImage Logo { get; set; }

    public IEnumerable<AppImage> Screenshots { get; set; }

    [XmlElement("squareImage")]
    public AppImage LogoSquare { get; set; }

    [XmlElement("doubleWideImage")]
    public AppImage LogoWide { get; set; }

    [XmlElement("backgroundImage")]
    public AppImage Background { get; set; }

    public void Cleanup()
    {
      if (Logo != null && String.IsNullOrEmpty(Logo.Urn)) Logo = null;
      if (LogoSquare != null && String.IsNullOrEmpty(LogoSquare.Urn)) LogoSquare = null;
      if (LogoWide != null && String.IsNullOrEmpty(LogoWide.Urn)) LogoWide = null;
      if (Background != null && String.IsNullOrEmpty(Background.Urn)) Background = null;
    }
  }


  public enum AppVisibilityStatus
  {
    Unknown,
    Live
  }
}
