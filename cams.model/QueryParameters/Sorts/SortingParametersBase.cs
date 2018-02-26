using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace cams.model.QueryParameters.Sorts
{
    /// <summary>
    /// Base class for sorting parameters.
    /// </summary>
    public class SortingParametersBase : Collection<Dictionary<string, SortingDirection>>
    {
    }
}