namespace cams.model.QueryParameters.Fields
{
    /// <summary>
    /// Defines a field option.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Fielding attribute.
        /// </summary>
        public string Attribute { get; set; }

        /// <summary>
        /// Fielding visibility.
        /// </summary>
        public FieldingVisibility Visibility { get; set; }
    }
}