using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace cams.model.QueryParameters.Filters
{
    /// <summary>
    /// Defines the filter operators.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FilterOperator
    {
        /// <summary>
        /// Logical operator AND.
        /// </summary>
        [EnumMember(Value = "and")]
        And,

        /// <summary>
        /// Logical operator OR.
        /// </summary>
        [EnumMember(Value = "or")]
        Or,

        /// <summary>
        /// Operator Equal.
        /// </summary>
        [EnumMember(Value = "eq")]
        Equal,

        /// <summary>
        /// Operator Not equal.
        /// </summary>
        [EnumMember(Value = "ne")]
        NotEqual,

        /// <summary>
        /// Operator In.
        /// </summary>
        [EnumMember(Value = "in")]
        In,

        /// <summary>
        /// Operator Greater than.
        /// </summary>
        [EnumMember(Value = "gt")]
        GreaterThan,

        /// <summary>
        /// Operator Greater or equal.
        /// </summary>
        [EnumMember(Value = "ge")]
        GreaterOrEqual,

        /// <summary>
        /// Operator Less than.
        /// </summary>
        [EnumMember(Value = "lt")]
        LessThan,

        /// <summary>
        /// Operator Less or equal.
        /// </summary>
        [EnumMember(Value = "le")]
        LessOrEqual
    }
}