using System;
using System.Runtime.Serialization;

namespace OnePeek.Entities
{
  public class AppPublisher
  {
    [DataMember(Name = "publisherid")]
    public string Id { get; set; }

    [DataMember(Name = "publisherguid")]
    public string Uid { get; set; }

    [DataMember(Name = "publisher")]
    public string Name { get; set; }

    [DataMember(Name = "publisherurl")]
    public Uri Url { get; set; }
  }
}
