using System;
using System.Xml.Serialization;
using System.Linq;

namespace OnePeek.Entities
{
  /// <summary>
  /// An image contains the ID which is necessary to get an appropriate URL for the image or the stream
  /// see OnePeek.Api.Extensions
  /// </summary>
  public partial class AppImage
  {
    /// <summary>
    /// ID.
    /// </summary>
    public string Id { get { return !String.IsNullOrWhiteSpace(Urn) ? Urn.Split(':').LastOrDefault() : null; } }

    /// <summary>
    /// URN
    /// </summary>
    [XmlElement("id")]
    public string Urn { get; set; }

    /// <summary>
    /// Rotation angle (is 0, 90, 180 or 270)
    /// </summary>
    public short Rotation { get; set; }
  }
}
