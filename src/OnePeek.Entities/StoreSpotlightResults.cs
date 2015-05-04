using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OnePeek.Entities
{
  public partial class StoreSpotlightResults
  {
    /// <summary>
    /// Count the results.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// The type of the store (WP or Windows 8/10)
    /// </summary>
    public StoreType StoreType { get; set; }

    /// <summary>
    /// The culture is relevant for the review results,
    /// as they are unique per country
    /// </summary>
    public StoreCultureType StoreCultureType { get; set; }

    /// <summary>
    /// Spotlight type. Either apps or games.
    /// </summary>
    public StoreSpotlightType StoreSpotlightType { get; set; }

    /// <summary>
    /// List of results. 
    /// Note that the AppMetadata POCO does not contain all data in this case, only necessary data to build a spotlight results list.
    /// </summary>
    public IEnumerable<AppMetadata> Results { get; set; }
  }


  public partial class StoreSpotlightIdResults
  {
    /// <summary>
    /// The culture is relevant for the review results,
    /// as they are unique per country
    /// </summary>
    public StoreCultureType StoreCultureType { get; set; }

    /// <summary>
    /// List of result ids.
    /// </summary>
    public IEnumerable<string> Ids { get; set; }
  }
}
