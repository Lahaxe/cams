using Newtonsoft.Json;
using System.ComponentModel;

namespace cams.model.QueryParameters.Pages
{
    public class PagingParametersBase
    {
        /// <summary>
        /// initializes a new instance of <see cref="PagingParametersBase"/>.
        /// </summary>
        public PagingParametersBase()
        {
            Index = 1;
            Size = 20;
        }

        /// <summary>
        /// Gets or sets paging index.
        /// </summary>
        [JsonProperty("index")]
        [DefaultValue(1)]
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets paging size.
        /// </summary>
        [JsonProperty("size")]
        [DefaultValue(20)]
        public int Size { get; set; }
    }
}
