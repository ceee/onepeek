using System;
using System.Xml.Serialization;

namespace OnePeek.Entities
{
  public class AppPublisher
  {
    [XmlElement("publisherid")]
    public string Id { get; set; }

    [XmlElement("publisherguid")]
    public string Uid { get; set; }

    [XmlElement("publisher")]
    public string Name { get; set; }

    [XmlElement("publisherurl")]
    public Uri Url { get; set; }
  }
}
