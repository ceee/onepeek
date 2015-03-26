using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnePeek.Entities
{
  public class AppRating
  {
    [XmlElement("averageuserrating")]
    public float AverageRating { get; set; }

    [XmlElement("userratingcount")]
    public int RatingCount { get; set; }
  }
}
