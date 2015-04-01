using System;
using System.Xml.Serialization;
using System.Linq;

namespace OnePeek.Entities
{
  public partial class AppImage
  {
    public string Id { get { return !String.IsNullOrWhiteSpace(Urn) ? Urn.Split(':').LastOrDefault() : null; } }

    [XmlElement("id")]
    public string Urn { get; set; }

    public short Rotation { get; set; }
  }
}
