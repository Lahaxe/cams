using System.ComponentModel;

namespace cams.model.QueryParameters.Filters
{
    /// <summary>
    /// Defines the filtering parameters.
    /// </summary>
    [TypeConverter(typeof(FilteringParametersConverter))]
    public class FilteringParameters
    {
        /// <summary>
        /// Gets or sets flag indicating if this object is valid or not.
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Gets or sets filter.
        /// </summary>
        public Filter Filter { get; set; }

        /// <summary>
        /// Initialize an instance of <see cref="FilteringParameters"/>.
        /// </summary>
        public FilteringParameters(bool isvalid = true)
        {
            IsValid = isvalid;
        }

        /// <summary>
        /// Initialize an instance of <see cref="FilteringParameters"/>.
        /// </summary>
        /// <param name="filteringbase">Filtering base parameters.</param>
        public FilteringParameters(FilteringParametersBase filteringbase)
        {
            IsValid = true;
            Filter = filteringbase as Filter;
        }
    }
}