using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OnePeek.Entities
{
  public partial class StoreSearchResults
  {
    /// <summary>
    /// Count the results.
    /// </summary>
    [XmlElement("itemsperpage")]
    public int Count { get; set; }

    /// <summary>
    /// Last modified date of the resource (by Microsoft).
    /// </summary>
    [XmlElement("updated")]
    public DateTime? StoreDataModifiedDate { get; set; }

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
    /// List of results. 
    /// Note that the AppMetadata POCO does not contain all data in this case, only necessary data build a search results list.
    /// </summary>
    public IEnumerable<AppMetadata> Results { get; set; }
  }
}
