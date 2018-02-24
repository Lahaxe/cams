using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace cams.model.QueryParameters.Sorts
{
    /// <summary>
    /// Defines the direction of sort.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortingDirection
    {
        /// <summary>
        /// Ascending direction.
        /// </summary>
        [EnumMember(Value = "asc")]
        Ascending,

        /// <summary>
        /// Descending direction.
        /// </summary>
        [EnumMember(Value = "desc")]
        Descending
    }
}