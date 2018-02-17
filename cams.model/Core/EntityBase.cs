namespace cams.model.Core
{
    /// <summary>
    /// Base class for all CAMS entities.
    /// </summary>
    public abstract class EntityBase : IIdentifiable
    {
        /// <summary>
        /// Gets or sets the identifer.
        /// </summary>
        public string Id { get; set; }
    }
}
