using cams.model.Core;

namespace cams.model.Items
{
    public class Item : EntityBase
    {
        public string Label { get; set; }

        public ItemType type { get; set; }
    }
}
