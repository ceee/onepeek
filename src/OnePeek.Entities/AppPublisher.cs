using System.Xml.Serialization;

namespace OnePeek.Entities
{
  [XmlRoot("feed")]
  public partial class AppPublisher
  {
    /// <summary>
    /// The ID of the publisher.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The URN of the publisher.
    /// </summary>
    [XmlElement("publisherGuid")]
    public string Urn { get; set; }

    /// <summary>
    /// The name of the publisher (individual or company).
    /// </summary>
    [XmlElement("publisher")]
    public string Name { get; set; }

    /// <summary>
    /// The URI of the publisher website.
    /// </summary>
    [XmlElement("publisherUrl")]
    public string Uri { get; set; }
  }
}
