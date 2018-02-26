namespace cams.model.QueryParameters.Sorts
{
    /// <summary>
    /// Defines a sort option.
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// Gets or sets the Sorting direction.
        /// </summary>
        public SortingDirection Direction { get; set; }

        /// <summary>
        /// Gets or sets the Sorting attribute.
        /// </summary>
        public string Attribute { get; set; }
    }
}