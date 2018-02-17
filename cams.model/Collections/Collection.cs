using cams.model.Core;
using cams.model.Items;
using System.Collections.ObjectModel;

namespace cams.model.Collections
{
    public class Collection : EntityBase
    {
        public Collection<Item> ListOfItems { get; set; }
    }
}
