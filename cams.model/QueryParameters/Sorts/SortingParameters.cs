using System.Collections.ObjectModel;
using System.ComponentModel;

namespace cams.model.QueryParameters.Sorts
{
    /// <summary>
    /// Defines the sorting parameters.
    /// </summary>
    [TypeConverter(typeof(SortingParametersConverter))]
    public class SortingParameters
    {
        /// <summary>
        /// Gets or sets flag indicating if this object is valid or not.
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public Collection<Sort> Sorts { get; set; }

        /// <summary>
        /// Initialize an instance of <see cref="SortingParameters"/>.
        /// </summary>
        public SortingParameters(bool isvalid = true)
        {
            IsValid = isvalid;
            Sorts = new Collection<Sort>();
        }

        /// <summary>
        /// Initialize an instance of <see cref="SortingParameters"/>.
        /// </summary>
        /// <param name="sortingbase">Sorting base parameters.</param>
        public SortingParameters(SortingParametersBase sortingbase)
        {
            IsValid = true;
            Sorts = new Collection<Sort>();

            foreach (var dict in sortingbase)
            {
                foreach (var value in dict)
                {
                    Sorts.Add(new Sort { Attribute = value.Key, Direction = value.Value });
                }
            }
        }
    }
}