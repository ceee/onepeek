using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnePeek.Entities
{
  public class AppRating
  {
    [DataMember(Name = "averageuserrating")]
    public float AverageRating { get; set; }

    [DataMember(Name = "userratingcount")]
    public int RatingCount { get; set; }
  }
}
