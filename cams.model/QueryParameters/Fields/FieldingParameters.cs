using System.Collections.ObjectModel;
using System.ComponentModel;

namespace cams.model.QueryParameters.Fields
{
    /// <summary>
    /// Defines the fielding parameters.
    /// </summary>
    [TypeConverter(typeof(FieldingParametersConverter))]
    public class FieldingParameters
    {
        /// <summary>
        /// Gets or sets flag indicating if this object is valid or not.
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public Collection<Field> Fields { get; set; }

        /// <summary>
        /// Initialize an instance of <see cref="FieldingParameters"/>.
        /// </summary>
        public FieldingParameters(bool isvalid = true)
        {
            IsValid = isvalid;
            Fields = new Collection<Field>();
        }

        /// <summary>
        /// Initialize an instance of <see cref="FieldingParameters"/>.
        /// </summary>
        /// <param name="fieldingbase">Fielding base parameters.</param>
        public FieldingParameters(FieldingParametersBase fieldingbase)
        {
            IsValid = true;
            Fields = new Collection<Field>();

            foreach (var dict in fieldingbase)
            {
                foreach (var value in dict)
                {
                    Fields.Add(new Field { Attribute = value.Key, Visibility = value.Value });
                }
            }
        }
    }
}