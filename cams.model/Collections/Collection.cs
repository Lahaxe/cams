using cams.model.Core;
using cams.model.Items;
using System.Collections.ObjectModel;

namespace cams.model.Collections
{
    /// <summary>
    /// Defines the collection.
    /// </summary>
    public class Collection : EntityBase
    {
        /// <summary>
        /// Gets or sets the items list.
        /// </summary>
        public Collection<Item> ListOfItems { get; set; }
    }
}