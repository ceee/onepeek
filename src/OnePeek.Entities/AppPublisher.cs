using System.Xml.Serialization;

namespace OnePeek.Entities
{
  [XmlRoot("feed")]
  public class AppPublisher
  {
    public string Id { get; set; }

    [XmlElement("publisherGuid")]
    public string Urn { get; set; }

    [XmlElement("publisher")]
    public string Name { get; set; }

    [XmlElement("publisherUrl")]
    public string Uri { get; set; }
  }
}
