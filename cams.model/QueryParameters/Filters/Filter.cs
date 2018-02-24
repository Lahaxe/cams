using Newtonsoft.Json;
using System.Collections.Generic;

namespace cams.model.QueryParameters.Filters
{
    public class Filter
    {
        /// <summary>
        /// Gets or sets filter operator.
        /// </summary>
        [JsonProperty("operator")]
        public FilterOperator Operator { get; set; }

        /// <summary>
        /// Gets or sets filter attribute identifier.
        /// </summary>
        [JsonProperty("attribute")]
        public string Attribute { get; set; }

        /// <summary>
        /// Gets or sets filter value.
        /// </summary>
        [JsonProperty("value")]
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets filter children.
        /// </summary>
        [JsonProperty("filters")]
        public ICollection<Filter> Filters { get; set; }
    }
}