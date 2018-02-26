using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace cams.model.QueryParameters.Fields
{
    /// <summary>
    /// Defines the field visibility.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FieldingVisibility
    {
        /// <summary>
        /// Visible.
        /// </summary>
        [EnumMember(Value = "on")]
        Visible,

        /// <summary>
        /// Hidden.
        /// </summary>
        [EnumMember(Value = "off")]
        Hidden
    }
}