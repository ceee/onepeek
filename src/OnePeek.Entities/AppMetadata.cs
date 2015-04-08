using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OnePeek.Entities
{
  [XmlRoot("feed")]
  public partial class AppMetadata
  {
    /// <summary>
    /// The ID of the app.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The type of the store (WP or Windows 8/10)
    /// </summary>
    public StoreType StoreType { get; set; }

    /// <summary>
    /// The culture is relevant for the metadata results,
    /// as they are unique per country
    /// </summary>
    public StoreCultureType StoreCultureType { get; set; }

    /// <summary>
    /// Last modified date of the resource (by Microsoft).
    /// </summary>
    [XmlElement("updated")]
    public DateTime? StoreDataModifiedDate { get; set; }

    /// <summary>
    /// Public name of the app.
    /// </summary>
    [XmlElement("title")]
    public string Name { get; set; }

    /// <summary>
    /// URN of the app.
    /// </summary>
    [XmlElement("id")]
    public string Urn { get; set; }

    /// <summary>
    /// When the app was first released to public.
    /// </summary>
    [XmlElement("releaseDate")]
    public DateTime ReleaseDate { get; set; }

    /// <summary>
    /// Description summary (seems like it can contain HTML).
    /// </summary>
    [XmlElement("content")]
    public string Text { get; set; }

    /// <summary>
    /// Text describing the last update.
    /// </summary>
    [XmlElement("whatsNew")]
    public string UpdateText { get; set; }

    /// <summary>
    /// Count of all In-App purchases.
    /// </summary>
    [XmlElement("iapCount")]
    public int IAPCount { get; set; }

    /// <summary>
    /// Defines if the app is visible in the store.
    /// </summary>
    [XmlElement("visibilityStatus")]
    public AppVisibilityStatus VisibilityStatus { get; set; }

    /// <summary>
    /// URL of the pricacy policy, can be null.
    /// </summary>
    [XmlElement("privacyPolicyUrl")]
    public string PrivacyPolicyUri { get; set; }

    /// <summary>
    /// Whether the app is a Universal app (both for WP + Windows).
    /// </summary>
    [XmlElement("isUniversal")]
    public bool IsUniversal { get; set; }

    /// <summary>
    /// Contains all images (background, logo, screenshots).
    /// </summary>
    public AppMetadataImages Images { get; set; }

    /// <summary>
    /// Information about the publisher
    /// </summary>
    public AppPublisher Publisher { get; set; }

    /// <summary>
    /// Rating information of the app in the current culture.
    /// </summary>
    public AppRating Rating { get; set; }
  }

  [XmlRoot("feed")]
  public partial class AppMetadataImages
  {
    /// <summary>
    /// Primary Logo.
    /// </summary>
    [XmlElement("image")]
    public AppImage Logo { get; set; }

    /// <summary>
    /// All screenshots of the app (culture variant).
    /// </summary>
    public IEnumerable<AppImage> Screenshots { get; set; }

    /// <summary>
    /// The logo in square format.
    /// </summary>
    [XmlElement("squareImage")]
    public AppImage LogoSquare { get; set; }

    /// <summary>
    /// The logo in wide format (as used in the wide tile).
    /// </summary>
    [XmlElement("doubleWideImage")]
    public AppImage LogoWide { get; set; }

    /// <summary>
    /// Background image (can be null) is used in the store details page.
    /// </summary>
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
