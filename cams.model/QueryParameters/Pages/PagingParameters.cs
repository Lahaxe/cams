using System.ComponentModel;

namespace cams.model.QueryParameters.Pages
{
    /// <summary>
    /// Defines the paging parameters.
    /// </summary>
    [TypeConverter(typeof(PagingParametersConverter))]
    public class PagingParameters : PagingParametersBase
    {
        /// <summary>
        /// Gets or sets flag indicating if this object is valid or not.
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// initializes a new instance of <see cref="PagingParameters"/>.
        /// </summary>
        public PagingParameters(bool isvalid = true) : base()
        {
            IsValid = isvalid;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="other"><see cref="PagingParametersBase"/> to copy.</param>
        public PagingParameters(PagingParametersBase other)
        {
            IsValid = true;
            if (other != null)
            {
                Index = other.Index;
                Size = other.Size;
            }
            else
            {
                Index = 1;
                Size = 20;
            }
        }
    }
}