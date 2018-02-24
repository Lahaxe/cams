namespace cams.model.QueryParameters.Sorts
{
    /// <summary>
    /// Defines a sort option.
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// Sorting direction.
        /// </summary>
        public SortingDirection Direction { get; set; }

        /// <summary>
        /// Sorting attribute.
        /// </summary>
        public string Attribute { get; set; }
    }
}