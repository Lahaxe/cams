using cams.model.Core;

namespace cams.model.Items
{
    /// <summary>
    /// Defines an item.
    /// </summary>
    public class Item : EntityBase
    {
        /// <summary>
        /// Gets or sets the item label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the item type.
        /// </summary>
        public ItemType type { get; set; }
    }
}